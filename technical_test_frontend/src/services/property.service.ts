import { axiosInstanceFormData, axiosInstanceJson } from "./instances";

export const getProperty = async (params?: {
  name?: string;
  address?: string;
  priceMin?: number;
  priceMax?: number;
}) => {
  const response = await axiosInstanceJson.get(`/Property`, { params });
  if (response) return response.data;
  throw response;
};

export const createProperty = async (data: FormData) => {
  const response = await axiosInstanceFormData.post("/Property", data);
  if (response) return response.data;
  throw response;
};

export const getPropertyById = async (id: string | null) => {
  const response = await axiosInstanceJson.get(`/Property/${id}`);
  if (response) return response.data;
  throw response;
}
