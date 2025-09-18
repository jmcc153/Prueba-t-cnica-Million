export type SalesType = {
  id: string,
  saleDate: string,
  saleTotal: number,
  tableNumber: number,
  status: "completed" | "pending"
}