public class Main {
    public static void main(String[] args) {
        try {
            ProcessBuilder process = new ProcessBuilder("java", "-cp", "out/production/A5", "Procesos");
            Process proc = process.start();
            // Si quieres ver la salida del proceso hijo:
            java.io.BufferedReader reader = new java.io.BufferedReader(
                    new java.io.InputStreamReader(proc.getInputStream())
            );
            String line;
            while ((line = reader.readLine()) != null) {
                System.out.println(line);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}