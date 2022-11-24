
public class Memory {
	  static String[] memory=new String[2048];
	  int[] data = {1024,2047};
	  int [] instructions = {0,1023};
	  boolean memWrite=false;
	  boolean memRead=false;
	  int memResult;
	 
	  
public String fetch(int value) {
	
	return memory[value];
	
	
}
public void MemoryAccess(Instruction i,ALU u) {
	if(u.aluResult<1024 || u.aluResult>2047) {
		System.out.println("Out of data bound");
	    return;
	}
	if(memWrite) {
		
		//memResult = i.r1;
		data[u.aluResult]= i.r1;
		
		//memWrite = false;
	}
	if(memRead) {
		memResult = data[u.aluResult];
		
		//memRead = false;
	}
}
public void addToMemory(String value , int address) {
	if(address >=0 && address<1024) {
	memory[address]=value;
	}
	else {
		System.out.println("No space for more instructions!!");
	}
}
	  


public static void main (String[]args) {
	/*String x = "0100";
	if(x.charAt(0)=='0') {
		System.out.println(Integer.parseInt(x,2));
	}
	else {
		//int y = Integer.parseInt(x);
		String y = x;
		y = y.replace("0", " ");
		y = y.replace("1", "0");
		y = y.replace(" ", "1");
		System.out.println(-1*(Integer.parseInt(y,2)+1));
	}*/
	
}
}