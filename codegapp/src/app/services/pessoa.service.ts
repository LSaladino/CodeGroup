import { Injectable } from '@angular/core';
import { MY_ENVIRONMENT } from '../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Pessoa } from '../Models/Pessoa';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  MainUrl = `${MY_ENVIRONMENT.mainUrl}/api/pessoa`;

  constructor(private http: HttpClient) { }

  //POST METHOD
  CreateNewPessoa(pessoa: Pessoa) {
    return this.http.post<Pessoa>(`${this.MainUrl}`, pessoa);
  }

  //GET ALL METHOD
  GetAllPessoas(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(`${this.MainUrl}`);
  }

  //GET BY ID
  GetPessoaById(id: number): Observable<Pessoa> {
    return this.http.get<Pessoa>(`${this.MainUrl}/${id}`);
  }

  // PUT METHOD
  UpdatePessoa(pessoa: Pessoa) {
    return this.http.put<Pessoa>(`${this.MainUrl}/`, pessoa);
  }

  // DELETE METHOD
  RemovePessoa(pessoaId: number) {
    return this.http.delete<Pessoa>(`${this.MainUrl}/${pessoaId}`);
  }

  //ANOTHER GET METHOD
  GetAllPessoaTwoFields(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(`${this.MainUrl}/twofields`);
  }

  //ANOTHER GET METHOD
  GetAllPessoaTwoFieldsById(id: number): Observable<Pessoa> {
    return this.http.get<Pessoa>(`${this.MainUrl}/twofieldsbyid/${id}`);
  }



}
