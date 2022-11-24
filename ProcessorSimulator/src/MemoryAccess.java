
public class MemoryAccess {
	String instruction="";
	int pc=-1;
	int opcode;
	int r1;
	int valueR1;
	boolean MemWrite=false;
	boolean MemRead=false;
	boolean RegWrite=false;
	boolean MemOrALU=false;
	boolean Zero=false;
	int aluResult;
	int memResult;
	
	public void access(Memory m){
		if((aluResult<1024 || aluResult>2047) &&(opcode==10 || opcode==11 )) {
			System.out.println("Out of data bound1");
		    return;
		}
		if(MemWrite) {
			
			//memResult = i.r1;
			m.memory[aluResult]= valueR1+"";
		}
		if(MemRead) {
			memResult =Integer.parseInt(m.memory[aluResult]);
		}

		
	}
	public void reset() {
		opcode=-1;
		instruction="" ;
		pc=-1;
		r1=0;
		
        valueR1=0;
		
		MemWrite=false;
		MemRead=false;
		RegWrite=false;
		MemOrALU=false;
		Zero=false;
	
		
	}
	public String toString() {
		return "..............................\n"+
			  "The input parameters/values are \n"+
	          "R1 = "+r1+"\n"+
	          "Value R1 = "+valueR1+"\n"+
	          "Memory Write Signal= "+MemWrite+"\n"+
	          "Memory Read Signal= "+MemRead+"\n"+
	          "Register Write Signal= "+RegWrite+"\n"+
	          "Memory or Alu= "+MemOrALU+"\n"+
	          "Zero Flag= " +Zero+"\n"+
	          "\n..............................\n";
	}
	public String data () {
	return  "[ In memory location "+ aluResult + " : "+valueR1+" is written in it ]";
	}
		
	}
	

