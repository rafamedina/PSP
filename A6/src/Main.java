import java.io.IOException;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) throws IOException {
    ProcessBuilder processs = new ProcessBuilder("java", "-cp","out/production/A6","Lanzador");
    Process proceso = processs.start();



    }
}