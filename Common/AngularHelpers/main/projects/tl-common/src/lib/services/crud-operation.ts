import { Observable } from 'rxjs';

export interface CrudOperations<T, ID> {
  save(t: T): Observable<T>;
  update(id: ID, t: T): Observable<T>;
  find(id: ID): Observable<T>;
  getAll(): Observable<T[]>;
  // getAllById(id: ID): Observable<T[]>;
  delete(id: ID): Observable<any>;
}
