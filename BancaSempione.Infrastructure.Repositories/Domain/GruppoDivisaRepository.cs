﻿using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class GruppoDivisaRepository(DivisaContext context): Repository<GruppoDivisa>(context), IGruppoDivisaRepository;
