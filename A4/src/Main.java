import java.io.*;

public class Main {

    public static void main(String[] args) throws IOException {
        try {
            System.out.println("Working directory: " + System.getProperty("user.dir"));
            ProcessBuilder proceso = new ProcessBuilder("java", "-cp", "out/production/A4", "proceso");
            proceso.directory(new File(System.getProperty("user.dir"))); // Usa el directorio actual
            Process process = proceso.start();



        } catch (Exception e) {
            BufferedWriter error = new BufferedWriter(new FileWriter("error.txt"));
                error.write(e.getMessage());

        }
    }
}