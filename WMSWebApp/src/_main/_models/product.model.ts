import { ProductPalletLine } from "./productPalletLine.model";
import { ErrorMessage } from "./error.message.model";

export interface Product extends ErrorMessage {
  data: {
    id: number;
    name: string;
    expirationDate: string;
    barcode: string;
    productPalletLines: ProductPalletLine[];
  }
}
