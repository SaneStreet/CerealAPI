import axios from "axios";
import type { Cereal } from "../types";

const api = axios.create({
  baseURL: "/api/Cereal", // proxy sørger for at sende dette til backend
});

export async function getCereals(): Promise<Cereal[]> {
  const res = await api.get("/");
  return res.data;
}

export async function getCereal(id: number): Promise<Cereal> {
  const res = await api.get(`/${id}`);
  return res.data;
}

export async function crtCereal(data: Partial<Cereal>) {
  return api.post("/", data);
}

export async function updCereal(id: number, data: Partial<Cereal>) {
  return api.put(`/${id}`, data);
}

export async function delCereal(id: number) {
  return api.delete(`/${id}`);
}