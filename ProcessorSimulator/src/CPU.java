import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;


public class CPU {
	HashMap<Integer ,String > instruction = new HashMap<>();
	Memory M = new Memory();
	HashMap<Integer,Register> GeneralRegister=new HashMap<>();
	PC pc ;
	Parser parser = new Parser();
	int clockCycle=1;
	ALU alu = new ALU();
	Decoder decoder = new Decoder();
	Execute execute=new Execute();
	MemoryAccess memoryAccess = new MemoryAccess();
	WriteBack writeBack = new WriteBack();
	String[] printInstruction=new String[5];
	boolean stop=false;
	int clackCycleToStop=0;
	
	public CPU() {
		for (int i=0;i<32;i++) {
			GeneralRegister.put(i,new Register(i));
		}
	}
	
	public void parse() {
		File file=new File("Code.txt");
		
		try {
			Scanner scan = new Scanner(file);
			int counter=0;
			
			
			while(scan.hasNextLine()){
				String []inst = parser.convertAssemblyToBin(scan.nextLine(),file);
				M.addToMemory(inst[0], pc.getValue()+counter);
				instruction.put(pc.getValue()+counter, inst[1]);
				counter++;
	
				
			}
		} catch (FileNotFoundException e) {
			System.out.println("File not found");
		}
		
	}
	public void bootUp() {
		pc=new PC(0);
		parse();
		run();
		
		
	}
	public void run() {
		while(true) {
			System.out.println("You are in clock cycle " + clockCycle);
			if(clockCycle%2==1) {
				WriteBack();
				
			}
			if(clockCycle%2==0) {
				MemAccess();
			}
			Execute();
			Decode();
			
			
			if(clockCycle%2==1) {
				Fetch();
			}
			
			System.out.println("***********//////////////**************");
			
				if(clockCycle%2==0) {
				System.out.println(printInstruction[1]);
				System.out.println(printInstruction[2]);
				System.out.println(printInstruction[3]);
				}
				else
				{
					System.out.println(printInstruction[0]);
						System.out.println(printInstruction[1]);
						System.out.println(printInstruction[2]);
						System.out.println(printInstruction[4]);
					
				}
			
			System.out.println("***********//////////////**************");
			
			
			if(stop==true && clockCycle==clackCycleToStop) {
				System.out.println("We have finished executing this program in "+clockCycle+" cycles");
				return;
			}
			clockCycle++;
			printInstruction=new String[5] ;
			
		}
	}
	
//el Pc haybawz el denia lw branched lmakan msh mawgod fil instruction memory!!!!!!	
	public void Fetch() {
		
		if(stop==false) {
			String I =M.fetch(pc.getValue());
			if(I==null) {
				stop=true;
				clackCycleToStop=clockCycle+4;
			}
			
		//	System.out.println(I +" "+ "FETCH");
			printInstruction[0]="We are fetching instruction "+instruction.get(pc.getValue())+ " from pc "+ pc.getValue();
			decoder.i=I;
			decoder.pc=pc.getValue();		
			if(pc.getValue()<1024) {
				pc.incValue();
		    }
		}
		else {
			printInstruction[0]="No More Instruction to fetch";
		
		}

			
		
		
		
	}
	public void Decode() {
		if(decoder.i==null || decoder.i=="") {
			printInstruction[1]=("There is no instruction to decode in this cycle");
			return;
		}
			if(clockCycle %2==0) {
					decoder.Decode1(GeneralRegister, execute);
			}
			else {
				decoder.Decode2(execute);
			
		}
			printInstruction[1]=("We are in the decode stage\n"+ "The instruction is "+ instruction.get(decoder.pc))
					+"\n"+decoder;
		
	}
	/*public void Decode1(Instruction i) {
		i.opcode = Integer.parseInt(i.binaryInst.substring(0, 4),2);
		i.r1 = Integer.parseInt(i.binaryInst.substring(4, 9),2);
		i.valueR1 = GeneralRegister.get(i.r1).getValue();
		i.r2 = Integer.parseInt(i.binaryInst.substring(9, 14),2);
		i.valueR2 = GeneralRegister.get(i.r2).getValue();
		
		//R-TYPE
		i.r3 = Integer.parseInt(i.binaryInst.substring(14, 19),2);
		i.valueR3 = GeneralRegister.get(i.r3).getValue();
		
		i.shamt=Integer.parseInt(i.binaryInst.substring(19),2);
		
		
		//I-type
		String x=i.binaryInst.substring(14);
		if(x.charAt(0)=='0') {
			i.immediate=(Integer.parseInt(x,2));
		}
		else {
			
			String y = x;
			y = y.replace("0", " ");
			y = y.replace("1", "0");
			y = y.replace(" ", "1");
		    i.immediate=(-1*(Integer.parseInt(y,2)+1));
		}

		
		//J-type
		i.address=Integer.parseInt(i.binaryInst.substring(4),2);

		
		
		
		
		
		
		
	}
    public void Decode2(Instruction i) {
    	switch(i.opcode) {
    	case(0):;
    	case(1):;
    	case(8):;
    	case(9): i.RegWrite=true;break;
    	case(2):;
    	case(3):;
    	case(5):;										
    	case(6):
    	        i.RegWrite=true;break;
    	case(4):;break;
    	case(10):
		    	i.MemRead=true;
		    	i.MemOrALU=true;
		    	i.RegWrite=true;break;
    	case(11):
		    	i.MemWrite=true;break;
    	case(7):;break;
    	
    	}
    	
		
	}
	*/
	
	public void Execute() {
		if(execute.Instruction==null || execute.Instruction=="") {
			printInstruction[2]=("There is no instruction to execute in this cycle");
			return;
		}
		

			if(clockCycle %2==0) {
					execute.alu(pc,decoder);
					printInstruction[2]=("We are in the execute stage\n"+ "The instruction is "+ instruction.get(execute.pc))+
							"\n"+execute;
			}
			else {
				printInstruction[2]=("We are in the execute stage\n"+ "The instruction is "+ instruction.get(execute.pc))+
						"\n"+execute;
				execute.memoryRegister(memoryAccess,writeBack,decoder);
		}
			
		}
		
		
		
	
	public void MemAccess() {
		if(memoryAccess.instruction==null || memoryAccess.instruction=="") {
			printInstruction[3]=("There is no instruction to access the memory in this cycle");
			return;
		}
		
	
			M.memRead=memoryAccess.MemRead;
			M.memWrite=memoryAccess.MemWrite;
			memoryAccess.access(M);
			String m="";
			if(memoryAccess.MemWrite) {
				m=memoryAccess.data();
			}
			
			
			writeBack.aluResult=memoryAccess.aluResult;
			writeBack.MemOrALU=memoryAccess.MemOrALU;
			writeBack.memResult=memoryAccess.memResult;
			writeBack.RegWrite=memoryAccess.RegWrite;
			writeBack.r1=memoryAccess.r1;
			writeBack.instruction=memoryAccess.instruction;
			writeBack.pc=memoryAccess.pc;
			printInstruction[3]=("We are in the memory stage\n"+ "The instruction is "+ instruction.get(memoryAccess.pc))+
					"\n"+memoryAccess
					+"\n#######"+m+"####################\n";
			
	
	
		
	}
	public void WriteBack() {
		if(writeBack.instruction==null || writeBack.instruction=="") {
			printInstruction[4] = ("There is no instruction to write back in this cycle");
			return;
		}
		String m="";
            if(writeBack.RegWrite) {
            	m=writeBack.changed(GeneralRegister);
            }
			writeBack.write(GeneralRegister);
			printInstruction[4]=("We are in the write back stage\n"+ "The instruction is "+ instruction.get(writeBack.pc))
					+"\n"+writeBack
					+"\n"+"#######"+m+"###########\n";
			
			
			
		}
		public void registers() {
			String m ="[ ";
			for(int i=0 ;i<32;i++ ) {
				m+=" R"+i+"= "+(GeneralRegister.get(i)).getValue()+", ";
				
			}
			m+=" ]";
			System.out.println("......................\n"+"Register File: \n"+m);
		}
		
		public static String middle(String s, int size, char pad) {
	        if (s == null || size <= s.length())
	            return s;
	        StringBuilder sb = new StringBuilder(size);
	        for (int i = 0; i < (size - s.length()) / 2; i++) {
	            sb.append(pad);
	        }
	        sb.append(s);
	        while (sb.length() < size) {
	            sb.append(pad);
	        }
	        return sb.toString();
	    }
		
		
		private void printAllMemory() {
	        System.out.println("Memory content:");
	        System.out.println("Memory Instructions Part:");
	        int i = 0 ;
	        System.out.println("-------------------------") ;
	         while (i < 1023) {

	           System.out.println("|"+ middle(i+"" ,11,' ')+"|" + middle(Memory.memory[i]+"" ,11,' ')+"|");
	            if (i!=1023)
	            System.out.println("-------------------------") ;

	            i++;
	        }
	        System.out.println("-------------------------") ;
	        System.out.println();
	        System.out.println("Memory Data Part:");
	        while (i < 2048) {
	            System.out.println("|"+ middle(i+"" ,11,' ')+"|" + middle(Memory.memory[i]+"" ,11,' ')+"|");
	             if (i!=1023)
	            System.out.println("-------------------------") ;

	            i++;
	        }

//	        System.out.println("-----------------------") ;


	        System.out.println("\n-----------------------------------------------------------------------\n");

	    }
		
		public void memory() {
			
		}
	
	public static void main (String[]args) {
		CPU cpu = new CPU();
		/*cpu.pc=new PC(0);
		cpu.GeneralRegister.get(2).setValue(3);
		cpu.GeneralRegister.get(3).setValue(4);
		cpu.parse();
		cpu.decoder.i=cpu.M.memory[0];
		cpu.decoder.Decode1(cpu.GeneralRegister,cpu.execute);
		cpu.decoder.Decode2(cpu.execute);
		cpu.execute.alu(cpu.pc,cpu.decoder);
		System.out.println(cpu.execute.opcode+" "+cpu.execute.valueR2+" "+cpu.execute.aluResult);
		cpu.execute.memoryRegister(cpu.memoryAccess);
		cpu.MemAccess();
		cpu.writeBack.write(cpu.GeneralRegister);
		System.out.println(cpu.execute.opcode+" "+cpu.execute.valueR1+" "+cpu.execute.aluResult+" "+cpu.GeneralRegister.get(3).getValue());*/
		cpu.bootUp();
	    cpu.registers();
	    cpu.printAllMemory();
		
	}
	
}
