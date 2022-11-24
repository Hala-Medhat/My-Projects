import java.util.HashMap;

public class Decoder {
	String i="";
	int pc=-1;
	int valueR1;
	int valueR2;
	int valueR3;
	int r1;
	int r2;
	int r3;
	int shamt;
	int opcode ;
	int immediate;
	int address;
	
	public void Decode1(HashMap<Integer,Register> GeneralRegister,Execute e) {
		if(i!=null) {
		opcode = Integer.parseInt(i.substring(0, 4),2);
		
		valueR1 = GeneralRegister.get(e.r1).getValue();
		
		valueR2 = GeneralRegister.get(e.r2).getValue();
		
		//R-TYPE
		
		
		r1 = Integer.parseInt(i.substring(4, 9),2);
    	r2 = Integer.parseInt(i.substring(9, 14),2);
    	r3 = Integer.parseInt(i.substring(14, 19),2);
       valueR1 = GeneralRegister.get(r1).getValue();
		
		valueR2 = GeneralRegister.get(r2).getValue();
		valueR3 = GeneralRegister.get(r3).getValue();
		
		shamt=Integer.parseInt(i.substring(19),2);
		
		
		//I-type
		String x=i.substring(14);
		if(x.charAt(0)=='0') {
			immediate=(Integer.parseInt(x,2));
		}
		else {
			
			String y = x;
			y = y.replace("0", " ");
			y = y.replace("1", "0");
			y = y.replace(" ", "1");
		    immediate=(-1*(Integer.parseInt(y,2)+1));
		}
		

		
		//J-type
	
		address=Integer.parseInt(i.substring(4),2);
		}

		
		
		
		
		
		
		
	}
	 public void Decode2(Execute e) {
	    	switch(opcode) {
	    	case(0):;
	    	case(1):;
	    	case(8):;
	    	case(9): 
	    	e.MemRead=false;
	    	e.MemWrite=false;
	    	e.MemOrALU=false;
	    	e.RegWrite=true;break;
	    	case(2):;
	    	case(3):;
	    	case(5):;										
	    	case(6):
	    		e.RegWrite=true;
		    	e.MemRead=false;
		    	e.MemOrALU=false;
		    	e.MemWrite=false;break;
	    	case(4):
		    	e.RegWrite=false;
		    	e.MemRead=false;
		    	e.MemOrALU=false;
		    	e.MemWrite=false;break;
	    	case(10):
			    	e.MemRead=true;
			    	e.MemOrALU=true;
			    	e.RegWrite=true;
			    	e.MemWrite=false;break;
	    	case(11):
	    		e.MemRead=false;
		    	e.MemOrALU=false;
		    	e.RegWrite=false;
			    e.MemWrite=true;break;
	    	case(7):
	    		e.RegWrite=false;
		    	e.MemRead=false;
		    	e.MemOrALU=false;
		    	e.MemWrite=false;;break;
	    	default:break;
	    	
	    	}
	    	e.Instruction=i;
	    	e.pc=pc;
	    	e.r1 = r1;
	    	e.r2 = r2;
	    	e.r3 = r3;
	    	e.valueR1=valueR1;
	    	e.valueR2=valueR2;
	    	e.valueR3=valueR3;
	    	e.immediate=immediate;
	    	e.address=address;
	    	e.opcode=opcode;
	    	e.shamt=shamt;
	   
	    
	    	
	    

	    	
	    	
			
		}
	 public void reset() {
		 i="";
		 int pc=-1;
	     valueR1=0;
	     valueR2=0;
		 valueR3=0;
         r1=0;
	     r2=0;
		 r3=0;
		 shamt=0;
	     opcode =-1;
		 immediate=0;
		 address=-1;
	 }
	 
	 public String toString() {
		 return "..............................\n"+
	       "The input parameter/value is instruction in binary \n"+i
	       +"\n..............................\n";
	 }

}

