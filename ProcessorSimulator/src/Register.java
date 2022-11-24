
public class Register {
	int number;
	private int value=0;
	boolean RegWrite=false;
	
	public Register (int number) {
		this.number=number;
	}
	
	
	
	public int getValue() {
		return value;
	}
	public void setValue(int value) {
		if(number ==0)
			return;
		this.value = value;
	}
}
