using LibHac;
using LibHac.Common;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSrv.FsCreator;

namespace Ryujinx.HLE.FileSystem
{
    public class EncryptedFileSystemCreator : IEncryptedFileSystemCreator
    {
        public Result Create(ref SharedRef<IFileSystem> outEncryptedFileSystem,
            ref readonly SharedRef<IFileSystem> baseFileSystem, IEncryptedFileSystemCreator.KeyId idIndex,
            in EncryptionSeed encryptionSeed)
        {
            if (idIndex < IEncryptedFileSystemCreator.KeyId.Save || idIndex > IEncryptedFileSystemCreator.KeyId.CustomStorage)
            {
                return ResultFs.InvalidArgument.Log();
            }

            // TODO: Reenable when AesXtsFileSystem is fixed.
            outEncryptedFileSystem = SharedRef<IFileSystem>.CreateMove(ref baseFileSystem.Ref);

            return Result.Success;
        }
    }
}
