import java.io.*;

public class metodos {

    int numero;

    public void tabla()  {
        try{
            System.out.println("Working adadad: " + System.getProperty("user.dir"));
            BufferedReader input  = new BufferedReader(new FileReader("input.txt"));
            this.numero = Integer.parseInt(input.readLine());
            input.close();

            BufferedWriter output = new BufferedWriter(new FileWriter("output.txt"));
            for (int i = 1; i <= 10; i++) {
                output.write(this.numero + " * " + i + " = " + this.numero * i + "\n");
            }
            output.close();
        } catch (Exception e){
            e.printStackTrace();
        }

    }

}
