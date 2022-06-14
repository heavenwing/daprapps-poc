// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------------------------------

namespace Dapr.Workflows.Workflow
{
    public class Credentials
    {
        public string StorageAccountKey { get; private set; }
        public string StorageAccountName { get; private set; }

        public string StorageEndpointSuffix { get; private set; }

        public Credentials(string storageAccountName, string storageAccountKey, string storageEndpointSuffix)
        {
            StorageAccountKey = storageAccountKey;
            StorageAccountName = storageAccountName;
            StorageEndpointSuffix = storageEndpointSuffix;
        }
    }
}