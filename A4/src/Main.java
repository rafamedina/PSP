import java.io.*;

public class Main {

    public static void main(String[] args) throws IOException {
        try {

            ProcessBuilder proceso = new ProcessBuilder("java", "-cp", "out/production/A4", "proceso");
            Process process = proceso.start();


        } catch (Exception e) {
            BufferedWriter error = new BufferedWriter(new FileWriter("error.txt"));
                error.write(e.getMessage());

        }
    }
}