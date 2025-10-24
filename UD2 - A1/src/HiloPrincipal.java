public class HiloPrincipal {
    public static void main(String[] args) {
        // Capturamos el hilo principal
        Thread hiloPrincipal = Thread.currentThread();

        // Imprimimos información sobre el hilo
        System.out.println("Nombre del hilo principal: " + hiloPrincipal.getName());
        System.out.println("El hilo principal está a punto de descansar 1 segundo...");

        try {
            // Hacemos que el hilo principal descanse 1 segundo (1000 milisegundos)
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            // Capturamos la excepción en caso de que el hilo sea interrumpido
            System.out.println("El hilo principal fue interrumpido.");
        }

        // Mensaje después de que el hilo haya despertado
        System.out.println("El hilo principal ha despertado después de 1 segundo de descanso.");
    }
}