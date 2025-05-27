public class Main {
    public static void main(String[] args) {
        double start = 3.3;
        int smaller = (int)Math.floor(start);
        int bigger = (int)Math.ceil(start);

        System.out.println("Alkuarvo: " + start);
        System.out.println("Pienempi kokonaisluku: " + smaller);
        System.out.println("Isompi kokonaisluku: " + bigger);
    }
}