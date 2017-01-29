import { Injectable } from "@angular/core";
import { Headers } from "@angular/http";

@Injectable()
export class OAuthHelper {
    constructor() { }

    public token;

    public getOAuthHeaders() {
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${this.token}`);
        return headers;
    }
}