import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DrinkType } from '../coffee-machine/coffee-machine.component';

@Injectable({
  providedIn: 'root',
})
export class DrinkService {

  constructor(private http: HttpClient) { }

  getDrinks(): Observable<DrinkType[]> {
    return this.http.get<DrinkType[]>('/api/drink');
  }
}
