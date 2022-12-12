export type CarBrand = {
  id?: string;
  name: string;
};
export type CarModel = {
  id?: string;
  name: string;
  carBrand: CarBrand;
};
export type CarPart = {
  id?: string;
  name: string;
  description: string;
  qty: number;
  carModel: CarModel;
  photoUrl: string;
};
export type User = {
  id?: string;
  userName: string;
};
export type LoginRequest = {
  userName: string;
  password: string;
};
export type LoginResponse = {
  accessToken: string;
};
export type RegisterRequest = {
  userName: string;
  email: string;
  password: string;
};
