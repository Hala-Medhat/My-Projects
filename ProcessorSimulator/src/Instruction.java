
public class Instruction {
	String binaryInst;
	int opcode;
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
	
	
public Instruction (String binaryInst) {
	this.binaryInst=binaryInst;
}
}
