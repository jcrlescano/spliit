import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Expense, CreateExpense, UpdateExpense } from '../models/expense.model';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  private apiUrl = `${environment.apiUrl}/expenses`;

  constructor(private http: HttpClient) {}

  getById(id: string): Observable<Expense> {
    return this.http.get<Expense>(`${this.apiUrl}/${id}`);
  }

  getByGroupId(groupId: string): Observable<Expense[]> {
    return this.http.get<Expense[]>(`${this.apiUrl}/group/${groupId}`);
  }

  create(expense: CreateExpense): Observable<Expense> {
    return this.http.post<Expense>(this.apiUrl, expense);
  }

  update(id: string, expense: UpdateExpense): Observable<Expense> {
    return this.http.put<Expense>(`${this.apiUrl}/${id}`, expense);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
