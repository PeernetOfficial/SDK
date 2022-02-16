﻿namespace Peernet.SDK.Models.Domain.Warehouse
{
    public enum WarehouseStatus
    {
        StatusOK = 0,
        StatusErrorCreateTempFile = 1,
        StatusErrorWriteTempFile = 2,
        StatusErrorCloseTempFile = 3,
        StatusErrorRenameTempFile = 4,
        StatusErrorCreatePath = 5,
        StatusErrorOpenFile = 7,
        StatusInvalidHash = 8,
        StatusFileNotFound = 9,
        StatusErrorDeleteFile = 10,
        StatusErrorReadFile = 11,
        StatusErrorSeekFile = 12,
        StatusErrorTargetExists = 13,
        StatusErrorCreateTarget = 14,
        StatusErrorCreateMerkle = 15,
        StatusErrorMerkleTreeFile = 16
    }
}