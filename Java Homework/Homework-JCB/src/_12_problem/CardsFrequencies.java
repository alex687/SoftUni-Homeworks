package _12_problem;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class CardsFrequencies {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String[] wordsArray;
        wordsArray = input.nextLine().split("[\\W ]+");

        Map<String, Integer> map = new HashMap<>();

        int maxCount = 1;
        ArrayList<String> list = new ArrayList<>();
        for (int i = 0; i < wordsArray.length; i++) {
            if (!list.contains(wordsArray[i])) {
                list.add(wordsArray[i]);
            }
        }

        for (int i = 0; i < list.size(); i++) {
            int counter = 0;
            String currentWord = list.get(i);

            for (int j = 0; j < wordsArray.length; j++) {
                if (currentWord.equals(wordsArray[j])) {
                    counter++;
                }
            }
            map.put(currentWord, counter);
        }

        float length = wordsArray.length;

        for (Map.Entry<String, Integer> entry : map.entrySet()) {
            String key = entry.getKey();
            int value = entry.getValue();

            System.out.printf("%s -> %.2f%s %n", key, (value / length) * 100, "%");
        }
    }
}