import { Injectable } from '@angular/core';
import { MY_ENVIRONMENT } from '../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Projeto } from '../Models/Projeto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProjetoService {

  MainUrl = `${MY_ENVIRONMENT.mainUrl}/api/projeto`;

  constructor(private http: HttpClient) { }

  //POST METHOD
  CreateNewProjeto(projeto: Projeto) {
    return this.http.post<Projeto>(`${this.MainUrl}`, projeto);
  }

   //GET BY ID
   GetProjetoById(id: number): Observable<Projeto> {
    return this.http.get<Projeto>(`${this.MainUrl}/${id}`);
  }

  //GET ALL METHOD
  GetAllProjetos(): Observable<Projeto[]> {
    return this.http.get<Projeto[]>(`${this.MainUrl}`);
  }

  // PUT METHOD
  UpdateProjeto(projeto: Projeto) {
    return this.http.put<Projeto>(`${this.MainUrl}/`, projeto);
  }

  // DELETE METHOD
  RemoveProjeto(projetoId: number) {
    return this.http.delete<Projeto>(`${this.MainUrl}/${projetoId}`);
  }

}
