export interface LoginRequestDto {
  email: string;
  password: string;
}

export interface AuthResponseDto {
  id: string;
  email: string;
  token: string;
}