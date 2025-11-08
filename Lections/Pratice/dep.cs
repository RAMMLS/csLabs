using System;

public delegate void TypeDelegate(object sz, EvArgs e);

public class EvArgs : EventArgs {  // Added 'public'
  public readonly int Delta;
  public readonly string Name;
  public EvArgs(int delta, string name) {
    Delta = delta;
    Name = name;
  }
}

class GenerateEvent {
  public event TypeDelegate Event;
  public void FuncGenerateEvent(int dlt, string nm) {
    if (Event != null) {
      if (dlt == 0) {
        return;
      }
      EvArgs e = new EvArgs(dlt, nm);
      Event(this, e);
    }
  }
}

class Rec {
  void onRec(object sz, EvArgs e) {
    Console.WriteLine("Delta = {0} Name = {1}", e.Delta, e.Name);
  }

  public Rec(GenerateEvent gn) {
    gn.Event += new TypeDelegate(onRec);
  }
}

class Program {
  static void Main(string[] args) {
    GenerateEvent gn = new GenerateEvent();
    Rec rc = new Rec(gn);
    gn.FuncGenerateEvent(-10, "Gazele");
  }
}
