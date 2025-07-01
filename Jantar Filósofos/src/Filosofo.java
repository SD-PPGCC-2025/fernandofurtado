import java.util.concurrent.locks.ReentrantLock;

public class Filosofo extends Thread {
    private final int id;
    private final ReentrantLock garfoEsquerdo;
    private final ReentrantLock garfoDireito;

    public Filosofo(int id, ReentrantLock garfoEsquerdo, ReentrantLock garfoDireito) {
        this.id = id;
        this.garfoEsquerdo = garfoEsquerdo;
        this.garfoDireito = garfoDireito;
    }

    private void pensar() throws InterruptedException {
        System.out.println("Filósofo " + (id+1) + " está pensando...");
        Thread.sleep((int) (Math.random() * 1000));
    }

    private void comer() throws InterruptedException {
        System.out.println("Filósofo " + (id +1)+ " está comendo...");
        Thread.sleep((int) (Math.random() * 1000));
    }

    @Override
    public void run() {
        try {
            while (true) {
                pensar();

                // Estratégia para evitar deadlock
                if (id == 4) {
                    garfoDireito.lock();
                    garfoEsquerdo.lock();
                } else {
                    garfoEsquerdo.lock();
                    garfoDireito.lock();
                }

                comer();

                garfoEsquerdo.unlock();
                garfoDireito.unlock();
            }
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        }
    }

}
