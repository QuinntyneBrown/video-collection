import { Author } from "./author.model";

export class Article {
    id: number;
    name: string;
    title: string;
    body: string;
    isPublished: boolean;
    author: Author;
    uniqueId: string;
    teaser: string;
    AuthorFullName: string;
    categoryName: string;
}
