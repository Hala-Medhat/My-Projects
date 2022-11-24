import java.util.HashMap;

public class WriteBack {
	String instruction="";
	int pc=-1;
	int r1;
	int memResult;
	int aluResult;
	boolean RegWrite=false;
	boolean MemOrALU=false;
	
public void write(HashMap<Integer,Register> GeneralRegister) {
	GeneralRegister.get(r1).RegWrite=RegWrite;
	int ovalue=-1;
	int nvalue=-1;
	if(GeneralRegister.get(r1).RegWrite) {
		if(MemOrALU) {
			ovalue =GeneralRegister.get(r1).getValue(); 
			GeneralRegister.get(r1).setValue(memResult);
			nvalue =GeneralRegister.get(r1).getValue(); 
		
		}
		else {
			ovalue =GeneralRegister.get(r1).getValue(); 
			GeneralRegister.get(r1).setValue(aluResult);
			nvalue =GeneralRegister.get(r1).getValue();
			
		}
		
		
		
		
	}
	
	
	
}
public void reset() {
	
	instruction="" ;
	pc=-1;
	r1=0;
	RegWrite=false;
	MemOrALU=false;
	

	
}
public String toString() {
	return "..............................\n"+
		  "The input parameters/values are \n "+
          "R1 = "+r1+"\n"+
          "Register Write Signal= "+RegWrite+"\n"+
          "Memory or Alu= "+MemOrALU+"\n"+
          "\n..............................\n";
}
public String changed(HashMap<Integer,Register> r) {
	String m="";
	if(MemOrALU) {
	    m ="The General Register "+r1+" is changed from ("+r.get(r1).getValue()+") to ("+memResult+")";
	}
	else {
		m ="The General Register "+r1+" is changed from ("+r.get(r1).getValue()+") to ("+aluResult+")";
	}
	return m;
}

}
