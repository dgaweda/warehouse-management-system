import { ProductPalletLine } from "./productPalletLine.model";
import { ErrorMessage } from "../common/models/error.message.model";

export interface Product extends ErrorMessage {
    id: number;
    name: string;
    expirationDate: string;
    barcode: string;
    productPalletLines: ProductPalletLine[];
}
