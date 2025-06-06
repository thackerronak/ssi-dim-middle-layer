/********************************************************************************
 * Copyright (c) 2025 BMW Group AG
 * Copyright 2025 SAP SE or an SAP affiliate company and ssi-dim-middle-layer contributors.
 *
 * See the NOTICE file(s) distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This program and the accompanying materials are made available under the
 * terms of the Apache License, Version 2.0 which is available at
 * https://www.apache.org/licenses/LICENSE-2.0.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 * SPDX-License-Identifier: Apache-2.0
 ********************************************************************************/

using Dim.Entities;
using Dim.Entities.Entities;
using Dim.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Org.Eclipse.TractusX.Portal.Backend.Framework.Processes.Library.Concrete.Entities;
using Org.Eclipse.TractusX.Portal.Backend.Framework.Processes.Library.DBAccess;
using Org.Eclipse.TractusX.Portal.Backend.Framework.Processes.Library.Enums;

namespace Dim.DbAccess;

public class DimProcessDbContextAccess(DimDbContext dbContext) :
    IProcessRepositoryContextAccess<Process, ProcessType<Process, ProcessTypeId>, ProcessStep<Process, ProcessTypeId, ProcessStepTypeId>, ProcessStepType<Process, ProcessTypeId, ProcessStepTypeId>, ProcessTypeId, ProcessStepTypeId>
{
    public DbSet<Process> Processes => dbContext.Processes;
    public DbSet<ProcessStep<Process, ProcessTypeId, ProcessStepTypeId>> ProcessSteps => dbContext.ProcessSteps;
    public DbSet<ProcessStepStatus<Process, ProcessTypeId, ProcessStepTypeId>> ProcessStepStatuses => dbContext.ProcessStepStatuses;

    public Process CreateProcess(Guid id, ProcessTypeId processTypeId, Guid version) => new(id, processTypeId, version);
    public ProcessStep<Process, ProcessTypeId, ProcessStepTypeId> CreateProcessStep(Guid id, ProcessStepTypeId processStepTypeId, ProcessStepStatusId processStepStatusId, Guid processId, DateTimeOffset now) => new(id, processStepTypeId, processStepStatusId, processId, now);
}
