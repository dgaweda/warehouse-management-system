import { productPalletLineModel } from "./productPalletLine.model";

export interface productModel {
    name: string;
    expirationDate: string;
    barcode: string;
    productPalletLines: productPalletLineModel[];
}