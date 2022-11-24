
public class Execute {
	int opcode=-1;
	String Instruction="" ;
	int pc=-1;
	int r1;
	int r2;
	int r3;
	int valueR1;
	int valueR2;
	int valueR3;
	int shamt;
	int immediate;
	int address;
	boolean MemWrite=false;
	boolean MemRead=false;
	boolean RegWrite=false;
	boolean MemOrALU=false;
	boolean Zero=false;
	int aluResult;
	
	
	public void alu(PC pc,Decoder d) {
		switch(opcode){
			case(0):aluResult=valueR2+valueR3;break;
			case(1):aluResult=valueR2-valueR3;break;
			case(2):aluResult=valueR2*immediate;break;
			case(3):aluResult=valueR2+immediate;break;
			case(4):if(valueR2!=valueR1) {
				
			pc.setValue(pc.getValue()-1+immediate);
			
			d.reset();
			}
			else{
				Zero=true;
				
			}
			break;
			case(5):aluResult=valueR2&immediate;break;
			case(6):aluResult=valueR2|immediate;break;
			case(8):aluResult = valueR2 << shamt;System.out.println(valueR2+" alu");break;
			case(9):aluResult = valueR2 >>> shamt;break;
			case(7):pc.setValue((pc.getValue() & 0b11110000000000000000000000000000)+immediate)
			;d.reset();break;
			case(10):;
			case(11):aluResult=valueR2+immediate;break;
			default:;break;
			
				
		}
	
		
		}
	
	public void memoryRegister(MemoryAccess m,WriteBack w,Decoder d){
		m.opcode=opcode;
		m.r1=r1;
		m.MemWrite=MemWrite;
		m.MemRead=MemRead;
		m.RegWrite=RegWrite;
		m.MemOrALU=MemOrALU;
		m.Zero=Zero;
		m.aluResult=aluResult;
		m.valueR1=valueR1;
		m.instruction=Instruction;
		m.pc=pc;
		reset();
		
	}
	public void reset() {
		opcode=-1;
		Instruction="" ;
		pc=-1;
		r1=0;
		r2=0;
		r3=0;
        valueR1=0;
		valueR2=0;
		valueR3=0;
		shamt=0;
		immediate=0;
		address=0;
		MemWrite=false;
		MemRead=false;
		RegWrite=false;
		MemOrALU=false;
		Zero=false;
	
		
	}
	public String toString() {
		return "..............................\n"+
			  "The input parameters/values are \n"+
	          "Opcode= "+opcode+"\n"+
	          "R1 = "+r1+"\n"+
	          "Value R1 = "+valueR1+"\n"+
	          "R2 = "+r2+"\n"+
	          "Value R2 = "+valueR2+"\n"+
	          "R3 = "+r3+"\n"+
	          "Value R3 = "+valueR3+"\n"+
	          "immediate= "+immediate+"\n"+
	          "Shamt= "+shamt+"\n"+
	          "address= "+address+"\n"+
	          "Memory Write Signal= "+MemWrite+"\n"+
	          "Memory Read Signal= "+MemRead+"\n"+
	          "Register Write Signal= "+RegWrite+"\n"+
	          "Memory or Alu= "+MemOrALU+"\n"+
	          "\n..............................\n";
	}
	
	
	

}
