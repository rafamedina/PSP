//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {

    public static void main(String[] args) {
        try{
            String archivo = "documento.txt";
            Process proceso = Runtime.getRuntime().exec("notepad.exe "+archivo);
            System.out.println("Proceso lanzado: notepad "+archivo);
        } catch (Exception e){
            e.printStackTrace();
        }
    }
}