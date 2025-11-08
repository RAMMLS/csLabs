using System;

namespace ClassExercise
{
    public enum ConferenceType {
        Science = 0, Student
    }
    
    public enum InstitutionType {
        University = 0, Scientific
    }

    class EventArgsConference : EventArgs {
        public ConferenceType type;
        public int visitors;
        public EventArgsConference(ConferenceType type, int visitors)
        {
            this.type = type;
            this.visitors = visitors;
        }
    }
    
    delegate void EventHadlerOnOrganizationCreateConference(object sender, EventArgsConference args);
    
    class Organization {
        public event EventHadlerOnOrganizationCreateConference OnCreateConference;

        public void CreateConference(ConferenceType type)
        {
            EventArgsConference args = new EventArgsConference(type, 0);
            if (this.OnCreateConference != null)
                this.OnCreateConference(this, args);

            Console.WriteLine($"Conference created: Type = {args.type}, Visitors = {args.visitors}");
        }
    }
    
    class Institution {
        private readonly InstitutionType type;
        private readonly int workers;

        //              Sciene Student
        // University
        // Scientific
        private static readonly float[][] conference_matrix = new float[][] {
            // Students = Workers * 10
            new float[] { 1 / 20f + 1 * 10f / 100f, 1 * 10 / 10f },
            new float[] { 1 / 10f,                  0           }
        };

        public Institution()
        {
            Array values = Enum.GetValues(typeof(InstitutionType));
            Random random = new Random();
            this.type = (InstitutionType)(values.GetValue(random.Next(values.Length)) ?? InstitutionType.University);
        
            this.workers = random.Next(40, 400);
            Console.WriteLine($"Institution: Type = {this.type}, Workers = {this.workers}");
        }
        
        public void HandleOnCreateConference(object sender, EventArgsConference args)
        {
            args.visitors += (int)Math.Round(
                this.workers * Institution.conference_matrix[(int)this.type][(int)args.type]
            );
        }
    }

    internal class Program {
        static void Main(string[] args)
        {
            Organization organization = new Organization();

            Random random = new Random();
            int count = random.Next(1, 10);
            for (int i = 0; i < count; i++) {
                Institution institution = new Institution();
                organization.OnCreateConference += institution.HandleOnCreateConference;
            }

            organization.CreateConference(ConferenceType.Science);
        }
    }
}
