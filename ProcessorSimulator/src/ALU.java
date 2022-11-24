
public class ALU {
	boolean Zero=false;
	int aluResult;
	
public void execute(Instruction i) {
	switch(i.opcode){
		case(0):aluResult=i.r2+i.r3;break;
		case(1):aluResult=i.r2-i.r3;break;
		case(2):aluResult=i.r2*i.immediate;break;
		case(3):aluResult=i.r2+i.immediate;break;
		case(4):if(i.r1==i.r2)Zero=true;;break;
		case(5):aluResult=i.r2&i.immediate;break;
		case(6):aluResult=i.r2|i.immediate;break;
		case(8):aluResult = i.r2 << i.shamt;break;
		case(9):aluResult = i.r2 >>> i.shamt;break;
		case(10):;
		case(11):aluResult=i.r2+i.immediate;break;
		case(7):;break;
			
	}
}

}
