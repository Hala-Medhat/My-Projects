import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Scanner;

public class Parser {
	
	
	public String[] convertAssemblyToBin(String instruction,File file) {
		instruction=instruction.toUpperCase();
		ArrayList<String> insts=new ArrayList (Arrays.asList(instruction.split("\\s+")));
		if(insts.get(0).charAt(insts.get(0).length()-1)==(':')) {
			insts.subList(1, insts.size());
		}
		for(String x:insts) {
			x.replaceAll("\\s", "");
		}
		String opcode="0b1111";
		String R1="";
		String immediate="";
		String instToStore="";
		String shmat="";
		System.out.println(insts);
		switch(insts.get(0)) {
		case("ADD"):opcode="0000";break;
		case("SUB"):opcode="0001";break;
		case("MULI"):opcode="0010";break;
		case("ADDI"):opcode="0011";break;
		case("BNE"):opcode="0100";break;
		case("ANDI"):opcode="0101";break;
		case("ORI"):opcode="0110";break;
		case("J"):opcode="0111";break;
		case("SLL"):opcode="1000";break;
		case("SRL"):opcode="1001";break;
		case("LW"):opcode="1010";break;
		case("SW"):opcode="1011";break;
		default:System.out.println("invalid instruction");return new String []{};
		}
		instToStore+=opcode;
		if(insts.get(0).equals("ADD") || insts.get(0).equals("SUB")) {
			System.out.println("jjj");
			for(int i=1;i<4;i++) {
				String number = insts.get(i).substring(1);
				R1=Integer.toBinaryString(Integer.parseInt(number));
				if(R1.length()<5) {
					while(R1.length()!=5) {
						R1="0"+R1;
					}
					
				}
				instToStore+=R1;
				if(i==3) {	
					instToStore+="0000000000000";
				}
					
					
				}
			}
			
			
			
		
		else {
			if(insts.get(0).equals("J")){
				R1=Integer.toBinaryString(Integer.parseInt(insts.get(1)));
				if(R1.length()<28) {
					while(R1.length()!=28) {
						R1="0"+R1;
					}
					
				}
				instToStore+=R1;
				
				
			}
			
		   else {
			   if(insts.get(0).equals("SRL") || insts.get(0).equals("SLL")) {
					for(int i=1;i<4;i++) {
						if(i==3) {
							instToStore+="00000";
							shmat=Integer.toBinaryString(Integer.parseInt(insts.get(3)));
							if(shmat.length()<13) {
								while(shmat.length()!=13) {
									shmat="0"+shmat;
								}
							}
							instToStore+=shmat;
						
							
						}
						else {
							String number = insts.get(i).substring(1);
							R1=Integer.toBinaryString(Integer.parseInt(number));
							if(R1.length()<5) {
								while(R1.length()!=5) {
									R1="0"+R1;
								}
							instToStore+=R1;
						}
					}
			}
			   }
			   else {
				   for(int i=1;i<4;i++) {
						if(i==3) {
							immediate=Integer.toBinaryString(Integer.parseInt(insts.get(3)));
							if(immediate.length()<18 && insts.get(3).charAt(0)!='-') {
								while(immediate.length()!=18) {
									immediate="0"+immediate;
								}
							}
							else if(immediate.length()>18 && insts.get(3).charAt(0)=='-')
								immediate=immediate.substring(17);
						
							instToStore+=immediate;
						}
						else {
							String number = insts.get(i).substring(1);
							
							R1=Integer.toBinaryString(Integer.parseInt(number));
						
							if(R1.length()<5) {
								while(R1.length()!=5) {
									R1="0"+R1;
								}}
							instToStore+=R1;
							
						}
						
				   
			   }
		   }
		}
		}
		return new String []{instToStore,instruction};
		
		
	}
	
	public int AddressLabel(File file , String label) {
		try {
			Scanner scan = new Scanner(file);
			int counter=0;
			
			while(scan.hasNextLine()){
				String[] x = scan.nextLine().split("\\s+");
				if(x[0].equals(label+":")) {
					return counter;
				}
				counter++;
			}
		} catch (FileNotFoundException e) {
			System.out.println("File not found");
		}
		return -1;
	}

}
