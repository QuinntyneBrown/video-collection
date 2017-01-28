import { environment } from "../environment";
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";

@Injectable()
export class ApiService {
    constructor(private _http: Http) { }
    
    public get _baseUrl() { return environment.baseUrl; }

}
