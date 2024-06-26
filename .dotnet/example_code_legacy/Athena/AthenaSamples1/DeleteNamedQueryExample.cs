﻿// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: Apache-2.0
﻿using System;
using System.Collections.Generic;
using System.Threading;
using Amazon;
using Amazon.Athena.Model;
using Amazon.Athena;

namespace AthenaSamples1
{
    /**
    * DeleteNamedQueryExample
    * -------------------------------------
    * This code shows how to delete a named query by using the named query ID.
    */
    class DeleteNamedQueryExample
    {
        public static void Example()
        {
            // Create an Amazon Athena client
            var athenaConfig = new AmazonAthenaConfig
            {
                RegionEndpoint = RegionEndpoint.USEast1,
                Timeout = TimeSpan.FromMilliseconds(ExampleConstants.CLIENT_EXECUTION_TIMEOUT)
            };
            var athenaClient = new AmazonAthenaClient(config: athenaConfig);

            String sampleNamedQueryId = getNamedQueryId(athenaClient);

            // Create the delete named query request
            var deleteNamedQueryRequest = new DeleteNamedQueryRequest()
            {
                NamedQueryId = sampleNamedQueryId
            };

            // Delete the named query
            var deleteNamedQueryResponse = athenaClient.DeleteNamedQuery(deleteNamedQueryRequest);
        }

        private static String getNamedQueryId(AmazonAthenaClient athenaClient)
        {
            // Create the NameQuery Request.
            CreateNamedQueryRequest createNamedQueryRequest = new CreateNamedQueryRequest()
            {
                Database = ExampleConstants.ATHENA_DEFAULT_DATABASE,
                QueryString = ExampleConstants.ATHENA_SAMPLE_QUERY,
                Name = "SampleQueryName",
                Description = "Sample Description"
            };

            // Create the named query. If it fails, an exception is thrown.
            var createNamedQueryResponse = athenaClient.CreateNamedQuery(createNamedQueryRequest);
            return createNamedQueryResponse.NamedQueryId;
        }

    }
}
