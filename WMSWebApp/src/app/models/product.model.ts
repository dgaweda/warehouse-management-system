import { productPalletLineModel } from "./productPalletLine.model";

export interface productModel {
    id: number;
    name: string;
    expirationDate: string;
    barcode: string;
    productPalletLines: productPalletLineModel[];
}