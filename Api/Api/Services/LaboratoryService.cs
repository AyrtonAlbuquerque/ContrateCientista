using Api.Contracts.Auth.Response;
using Api.Contracts.LanguageApi;
using Api.Domain.Model;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using Api.Utilities;
using IListExtension;
using Mapster;
using Laboratory = Api.Contracts.Common.Laboratory;

namespace Api.Services
{
    public class LaboratoryService(
        IUserService userService,
        ITokenService tokenService,
        ILanguageService languageService,
        IUserRepository userRepository,
        IPersonRepository personRepository,
        IKeywordRepository keywordRepository,
        ISoftwareRepository softwareRepository,
        IEquipmentRepository equipmentRepository,
        ILaboratoryRepository laboratoryRepository,
        ISocialMediaRepository socialMediaRepository) : ILaboratoryService
    {
        public async Task<Laboratory> Get()
        {
            var user = await userService.GetUserAsync();

            ForbiddenException.ThrowIfNull(user.Laboratory, "Usuário não corresponde a um laboratório, apenas laboratórios podem obter seus dados");

            return user.Laboratory.Adapt<Laboratory>();
        }

        public async Task<LoginResponse> Register(Laboratory laboratory)
        {
            BadRequestException.ThrowIf(await userRepository.ExistsAsync(laboratory.Responsible.Email), "E-mail já cadastrado.");
            BadRequestException.ThrowIf(!ValidationHelper.ValidatePassword(laboratory.Responsible.Password), "Senha inválida. A senha deve conter pelo menos 8 caracteres, uma letra e um número.");

            var keywords = await languageService.Extract(new Description { Text = laboratory.Description });
            var user = await userRepository.InsertAsync((keywords, laboratory).Adapt<User>());
            var token = tokenService.Create(user);

            return (user, token).Adapt<LoginResponse>();
        }

        public async Task<Laboratory> Update(Laboratory laboratory)
        {
            var user = await userService.GetUserAsync();
            var person = await personRepository.GetAsync(laboratory.Responsible?.Email, laboratory.Responsible?.Phone);

            ForbiddenException.ThrowIfNull(user.Laboratory, "Usuário não corresponde a um laboratório, apenas laboratórios podem atualizar seus dados");
            BadRequestException.ThrowIfNull(person, "O email e telefone do responsável pelo laboratório não corresponde ao cadastrado");

            user.Laboratory.Name = laboratory.Name ?? user.Laboratory.Name;
            user.Laboratory.Code = laboratory.Code ?? user.Laboratory.Code;
            user.Laboratory.Description = laboratory.Description ?? user.Laboratory.Description;
            user.Laboratory.Certificates = laboratory.Certificates ?? user.Laboratory.Certificates;
            user.Laboratory.FoundationDate = laboratory.FoundationDate ?? user.Laboratory.FoundationDate;
            user.Laboratory.Responsible.Name = laboratory.Responsible?.Name ?? person.Name;
            user.Laboratory.Responsible.Department = laboratory.Responsible?.Department ?? person.Department;
            user.Laboratory.Address.Street = laboratory.Address.Street ?? user.Laboratory.Address.Street;
            user.Laboratory.Address.Number = laboratory.Address.Number ?? user.Laboratory.Address.Number;
            user.Laboratory.Address.Neighborhood = laboratory.Address.Neighborhood ?? user.Laboratory.Address.Neighborhood;
            user.Laboratory.Address.City = laboratory.Address.City ?? user.Laboratory.Address.City;
            user.Laboratory.Address.State = laboratory.Address.State ?? user.Laboratory.Address.State;
            user.Laboratory.Address.Country = laboratory.Address.Country ?? user.Laboratory.Address.Country;
            user.Laboratory.Address.Extra = laboratory.Address.Extra ?? user.Laboratory.Address.Extra;

            if (laboratory.Softwares?.Count > 0)
            {
                await softwareRepository.DeleteAsync(user.Laboratory.Softwares);
                user.Laboratory.Softwares = laboratory.Softwares.Adapt<IList<Software>>();
            }

            if (laboratory.Equipments?.Count > 0)
            {
                await equipmentRepository.DeleteAsync(user.Laboratory.Equipments);
                user.Laboratory.Equipments = laboratory.Equipments.Adapt<IList<Equipment>>();
            }

            if (laboratory.SocialMedias?.Count > 0)
            {
                await socialMediaRepository.DeleteAsync(user.Laboratory.SocialMedias);
                user.Laboratory.SocialMedias = laboratory.SocialMedias.Adapt<IList<SocialMedia>>();
            }

            if (laboratory.Keywords?.Count > 0)
            {
                var keywords = await languageService.Extract(new Description { Text = user.Laboratory.Description });

                await keywordRepository.DeleteAsync(user.Laboratory.Keywords);
                user.Laboratory.Keywords.AddRange(keywords.Select(x => new Keyword { Text = x.Text.ToLower(), Weight = x.Weight })
                    .Concat(laboratory.Keywords.Select(x => new Keyword { Text = x.ToLower(), Weight = 1 }))
                    .GroupBy(x => x.Text)
                    .Select(x => x.OrderByDescending(k => k.Weight).First()));
            }

            await laboratoryRepository.UpdateAsync(user.Laboratory);

            return user.Laboratory.Adapt<Laboratory>();
        }
    }
}