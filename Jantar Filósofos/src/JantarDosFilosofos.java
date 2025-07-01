import java.util.concurrent.locks.ReentrantLock;

public class JantarDosFilosofos {
    public static void main(String[] args) {
        ReentrantLock[] garfos = new ReentrantLock[5];

        for (int i = 0; i < 5; i++) {
            garfos[i] = new ReentrantLock();
        }

        Filosofo[] filosofos = new Filosofo[5];

        for (int i = 0; i < 5; i++) {
            ReentrantLock garfoEsquerdo = garfos[i];
            ReentrantLock garfoDireito = garfos[(i + 1) % 5];

            filosofos[i] = new Filosofo(i, garfoEsquerdo, garfoDireito);
            filosofos[i].start();
        }
    }
}
