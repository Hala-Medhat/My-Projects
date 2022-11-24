
public class PC {
	private int value;
	
	public PC(int value) {
		if(value>=0 && value<1024) {
		this.value=value;
		}
		else
			System.out.print("Value out of bound");
	}

	public int getValue() {
		return value;
	}

	public void incValue() {
		if(value>=0 && value<1024) {
		this.value++;
		}
		else {
			System.out.println("No more instructions to fetch");
			}
			
			
		}
	public void setValue(int x) {
	     value=x;
	}

}

