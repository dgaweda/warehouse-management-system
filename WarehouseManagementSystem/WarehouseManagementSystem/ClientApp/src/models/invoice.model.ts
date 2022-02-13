export interface InvoiceModel {
    id: number;
    invoiceNumber?: string;
    provider?: string;
    creationDateTime?: string;
    receiptDateTime?: string;
    deliveryId?: string;
}