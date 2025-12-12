import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Group, CreateGroup, UpdateGroup } from '../models/group.model';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  private apiUrl = `${environment.apiUrl}/groups`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Group[]> {
    return this.http.get<Group[]>(this.apiUrl);
  }

  getById(id: string): Observable<Group> {
    return this.http.get<Group>(`${this.apiUrl}/${id}`);
  }

  create(group: CreateGroup): Observable<Group> {
    return this.http.post<Group>(this.apiUrl, group);
  }

  update(id: string, group: UpdateGroup): Observable<Group> {
    return this.http.put<Group>(`${this.apiUrl}/${id}`, group);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
