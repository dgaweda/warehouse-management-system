export interface Page{
  route: string;
  name: string;
}

export const LoginPage: Page[] = [{route: '/login', name: 'Logowanie'}];

export const DefaultPages: Page[]= [
  {route: '/home', name: 'Strona Główna'},
  {route: '/order', name: 'Zamówienia'},
  {route: '/delivery', name: 'Dostawy'}
];
