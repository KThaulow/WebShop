import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name: 'customtitlecase'
})
export class CustomTitleCasePipe implements PipeTransform {
    transform(title: string): string {
        if (title != null) {
            let words = title.split(' ');
            let titleWords: string[] = [];

            for (let i = 0; i < words.length; i++) {
                var word = words[i];
                var titleWord = word.toLowerCase();
                if (i == 0
                    || (titleWord != "of" && titleWord != "the")) {
                    titleWord = titleWord.charAt(0).toUpperCase() + titleWord.slice(1).toLowerCase();
                }

                titleWords.push(titleWord);
            }

            return titleWords.join(' ');
        }
        return title;
    }
}