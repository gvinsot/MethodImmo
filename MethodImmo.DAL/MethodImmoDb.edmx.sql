
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/22/2016 22:25:11
-- Generated from EDMX file: D:\Projects\MethodImmo\MethodImmo\MethodImmo.DAL\MethodImmoDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccesUtilisateurSet'
CREATE TABLE [dbo].[AccesUtilisateurSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [MotDePasse] nvarchar(max)  NOT NULL,
    [Utilisateur] nvarchar(max)  NOT NULL,
    [Individu_Id] bigint  NOT NULL
);
GO

-- Creating table 'ActionSet'
CREATE TABLE [dbo].[ActionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DateDeCreation] datetime  NOT NULL,
    [DateDeDebutDeRealisation] datetime  NOT NULL,
    [DateDeFinDeRealisationConstate] datetime  NOT NULL,
    [DateDeFinDeRealisationPrevisionnelle] datetime  NOT NULL,
    [TypeAction] bigint  NOT NULL,
    [OrigineContrat_Id] bigint  NULL,
    [ActionAction_Action1_Id] bigint  NOT NULL
);
GO

-- Creating table 'CommentaireSet'
CREATE TABLE [dbo].[CommentaireSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Contenu] nvarchar(max)  NOT NULL,
    [DateDeCreation] nvarchar(max)  NOT NULL,
    [CommentaireDeContrat_Id] bigint  NULL,
    [CommentaireDAction_Id] bigint  NULL,
    [CommentaireDePersonne_Id] bigint  NULL,
    [CommentaireDeLot_Id] bigint  NULL,
    [CommentaireDeImmeuble_Id] bigint  NULL,
    [Auteur_Id] bigint  NOT NULL
);
GO

-- Creating table 'CompteBancaireSet'
CREATE TABLE [dbo].[CompteBancaireSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Immeuble_Id] bigint  NULL,
    [Action_Id] bigint  NULL
);
GO

-- Creating table 'ContratSet'
CREATE TABLE [dbo].[ContratSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DateDeDebut] nvarchar(max)  NOT NULL,
    [DateDeFin] nvarchar(max)  NOT NULL,
    [TypeDeContrat] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CoordonneesBancairesSet'
CREATE TABLE [dbo].[CoordonneesBancairesSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [BIC] nvarchar(max)  NOT NULL,
    [IBAN] nvarchar(max)  NOT NULL,
    [Proprietaire] nvarchar(max)  NOT NULL,
    [CompteBancaire_Id] bigint  NOT NULL,
    [Personne_Id] bigint  NOT NULL
);
GO

-- Creating table 'DocumentationSet'
CREATE TABLE [dbo].[DocumentationSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Contrat_Id] bigint  NULL,
    [CompteBancaire_Id] bigint  NOT NULL
);
GO

-- Creating table 'DroitsGroupeUtilisateursSet'
CREATE TABLE [dbo].[DroitsGroupeUtilisateursSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [GroupeDePersonnes_Id] bigint  NOT NULL
);
GO

-- Creating table 'GroupeDePersonnesSet'
CREATE TABLE [dbo].[GroupeDePersonnesSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [EntrepriseDAppartenance_Id] bigint  NOT NULL,
    [Lot1_Id] bigint  NOT NULL
);
GO

-- Creating table 'ImmeubleSet'
CREATE TABLE [dbo].[ImmeubleSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [TotalTantiemes] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonneSet'
CREATE TABLE [dbo].[PersonneSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [DateDebut] nvarchar(max)  NOT NULL,
    [DateFin] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CoordonneesDeContactSet'
CREATE TABLE [dbo].[CoordonneesDeContactSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Personne_Id] bigint  NOT NULL
);
GO

-- Creating table 'AdressePostaleSet'
CREATE TABLE [dbo].[AdressePostaleSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Rue] nvarchar(max)  NOT NULL,
    [CodePostal] nvarchar(max)  NOT NULL,
    [Ville] nvarchar(max)  NOT NULL,
    [Pays] nvarchar(max)  NOT NULL,
    [Acces] nvarchar(max)  NOT NULL,
    [CoordonneesDeContact_Id] bigint  NULL,
    [Immeuble_Id] bigint  NULL
);
GO

-- Creating table 'AdresseEmailSet'
CREATE TABLE [dbo].[AdresseEmailSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [CoordonneesDeContact_Id] bigint  NOT NULL
);
GO

-- Creating table 'TelephoneSet'
CREATE TABLE [dbo].[TelephoneSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Numero] nvarchar(max)  NOT NULL,
    [CoordonneesDeContact_Id] bigint  NOT NULL
);
GO

-- Creating table 'VersionDeDocumentSet'
CREATE TABLE [dbo].[VersionDeDocumentSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Documentation_Id] bigint  NOT NULL
);
GO

-- Creating table 'LotSet'
CREATE TABLE [dbo].[LotSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Tantiemes] nvarchar(max)  NOT NULL,
    [Immeuble_Id] bigint  NOT NULL,
    [Proprietaire_Id] bigint  NOT NULL
);
GO

-- Creating table 'PartenaireSet'
CREATE TABLE [dbo].[PartenaireSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FonctionDuPartenaire] nvarchar(max)  NOT NULL,
    [Personne_Id] bigint  NOT NULL,
    [PartenaireDe_Id] bigint  NOT NULL
);
GO

-- Creating table 'PersonneSet_Entreprise'
CREATE TABLE [dbo].[PersonneSet_Entreprise] (
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'ActionSet_Anomalie'
CREATE TABLE [dbo].[ActionSet_Anomalie] (
    [Id] bigint  NOT NULL,
    [AnomalieDeDocumentation_Id] bigint  NULL,
    [AnomalieDeVersionDeDocument_Id] bigint  NULL,
    [AnomalieDeContrat_Id] bigint  NULL,
    [AnomalieDeCompteBancaire_Id] bigint  NULL
);
GO

-- Creating table 'GroupeDePersonnesSet_GroupeDeRepartition'
CREATE TABLE [dbo].[GroupeDePersonnesSet_GroupeDeRepartition] (
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'PersonneSet_Individu'
CREATE TABLE [dbo].[PersonneSet_Individu] (
    [Prenom] nvarchar(max)  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'ContratGroupeDePersonnes'
CREATE TABLE [dbo].[ContratGroupeDePersonnes] (
    [Contrats_Id] bigint  NOT NULL,
    [GroupesContractants_Id] bigint  NOT NULL
);
GO

-- Creating table 'GroupeDePersonnesPersonne'
CREATE TABLE [dbo].[GroupeDePersonnesPersonne] (
    [Groupes_Personne_Id] bigint  NOT NULL,
    [Personnes_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AccesUtilisateurSet'
ALTER TABLE [dbo].[AccesUtilisateurSet]
ADD CONSTRAINT [PK_AccesUtilisateurSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActionSet'
ALTER TABLE [dbo].[ActionSet]
ADD CONSTRAINT [PK_ActionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentaireSet'
ALTER TABLE [dbo].[CommentaireSet]
ADD CONSTRAINT [PK_CommentaireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompteBancaireSet'
ALTER TABLE [dbo].[CompteBancaireSet]
ADD CONSTRAINT [PK_CompteBancaireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContratSet'
ALTER TABLE [dbo].[ContratSet]
ADD CONSTRAINT [PK_ContratSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoordonneesBancairesSet'
ALTER TABLE [dbo].[CoordonneesBancairesSet]
ADD CONSTRAINT [PK_CoordonneesBancairesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentationSet'
ALTER TABLE [dbo].[DocumentationSet]
ADD CONSTRAINT [PK_DocumentationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DroitsGroupeUtilisateursSet'
ALTER TABLE [dbo].[DroitsGroupeUtilisateursSet]
ADD CONSTRAINT [PK_DroitsGroupeUtilisateursSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupeDePersonnesSet'
ALTER TABLE [dbo].[GroupeDePersonnesSet]
ADD CONSTRAINT [PK_GroupeDePersonnesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ImmeubleSet'
ALTER TABLE [dbo].[ImmeubleSet]
ADD CONSTRAINT [PK_ImmeubleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonneSet'
ALTER TABLE [dbo].[PersonneSet]
ADD CONSTRAINT [PK_PersonneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoordonneesDeContactSet'
ALTER TABLE [dbo].[CoordonneesDeContactSet]
ADD CONSTRAINT [PK_CoordonneesDeContactSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdressePostaleSet'
ALTER TABLE [dbo].[AdressePostaleSet]
ADD CONSTRAINT [PK_AdressePostaleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdresseEmailSet'
ALTER TABLE [dbo].[AdresseEmailSet]
ADD CONSTRAINT [PK_AdresseEmailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TelephoneSet'
ALTER TABLE [dbo].[TelephoneSet]
ADD CONSTRAINT [PK_TelephoneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VersionDeDocumentSet'
ALTER TABLE [dbo].[VersionDeDocumentSet]
ADD CONSTRAINT [PK_VersionDeDocumentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LotSet'
ALTER TABLE [dbo].[LotSet]
ADD CONSTRAINT [PK_LotSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PartenaireSet'
ALTER TABLE [dbo].[PartenaireSet]
ADD CONSTRAINT [PK_PartenaireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonneSet_Entreprise'
ALTER TABLE [dbo].[PersonneSet_Entreprise]
ADD CONSTRAINT [PK_PersonneSet_Entreprise]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActionSet_Anomalie'
ALTER TABLE [dbo].[ActionSet_Anomalie]
ADD CONSTRAINT [PK_ActionSet_Anomalie]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupeDePersonnesSet_GroupeDeRepartition'
ALTER TABLE [dbo].[GroupeDePersonnesSet_GroupeDeRepartition]
ADD CONSTRAINT [PK_GroupeDePersonnesSet_GroupeDeRepartition]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonneSet_Individu'
ALTER TABLE [dbo].[PersonneSet_Individu]
ADD CONSTRAINT [PK_PersonneSet_Individu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Contrats_Id], [GroupesContractants_Id] in table 'ContratGroupeDePersonnes'
ALTER TABLE [dbo].[ContratGroupeDePersonnes]
ADD CONSTRAINT [PK_ContratGroupeDePersonnes]
    PRIMARY KEY CLUSTERED ([Contrats_Id], [GroupesContractants_Id] ASC);
GO

-- Creating primary key on [Groupes_Personne_Id], [Personnes_Id] in table 'GroupeDePersonnesPersonne'
ALTER TABLE [dbo].[GroupeDePersonnesPersonne]
ADD CONSTRAINT [PK_GroupeDePersonnesPersonne]
    PRIMARY KEY CLUSTERED ([Groupes_Personne_Id], [Personnes_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CoordonneesDeContact_Id] in table 'TelephoneSet'
ALTER TABLE [dbo].[TelephoneSet]
ADD CONSTRAINT [FK_CoordonneesDeContactTelephone]
    FOREIGN KEY ([CoordonneesDeContact_Id])
    REFERENCES [dbo].[CoordonneesDeContactSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoordonneesDeContactTelephone'
CREATE INDEX [IX_FK_CoordonneesDeContactTelephone]
ON [dbo].[TelephoneSet]
    ([CoordonneesDeContact_Id]);
GO

-- Creating foreign key on [CoordonneesDeContact_Id] in table 'AdresseEmailSet'
ALTER TABLE [dbo].[AdresseEmailSet]
ADD CONSTRAINT [FK_CoordonneesDeContactAdresseEmail]
    FOREIGN KEY ([CoordonneesDeContact_Id])
    REFERENCES [dbo].[CoordonneesDeContactSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoordonneesDeContactAdresseEmail'
CREATE INDEX [IX_FK_CoordonneesDeContactAdresseEmail]
ON [dbo].[AdresseEmailSet]
    ([CoordonneesDeContact_Id]);
GO

-- Creating foreign key on [CoordonneesDeContact_Id] in table 'AdressePostaleSet'
ALTER TABLE [dbo].[AdressePostaleSet]
ADD CONSTRAINT [FK_CoordonneesDeContactAdressePostale]
    FOREIGN KEY ([CoordonneesDeContact_Id])
    REFERENCES [dbo].[CoordonneesDeContactSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoordonneesDeContactAdressePostale'
CREATE INDEX [IX_FK_CoordonneesDeContactAdressePostale]
ON [dbo].[AdressePostaleSet]
    ([CoordonneesDeContact_Id]);
GO

-- Creating foreign key on [Immeuble_Id] in table 'AdressePostaleSet'
ALTER TABLE [dbo].[AdressePostaleSet]
ADD CONSTRAINT [FK_ImmeubleAdressePostale]
    FOREIGN KEY ([Immeuble_Id])
    REFERENCES [dbo].[ImmeubleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImmeubleAdressePostale'
CREATE INDEX [IX_FK_ImmeubleAdressePostale]
ON [dbo].[AdressePostaleSet]
    ([Immeuble_Id]);
GO

-- Creating foreign key on [Immeuble_Id] in table 'CompteBancaireSet'
ALTER TABLE [dbo].[CompteBancaireSet]
ADD CONSTRAINT [FK_ImmeubleCompteBancaire]
    FOREIGN KEY ([Immeuble_Id])
    REFERENCES [dbo].[ImmeubleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImmeubleCompteBancaire'
CREATE INDEX [IX_FK_ImmeubleCompteBancaire]
ON [dbo].[CompteBancaireSet]
    ([Immeuble_Id]);
GO

-- Creating foreign key on [CompteBancaire_Id] in table 'CoordonneesBancairesSet'
ALTER TABLE [dbo].[CoordonneesBancairesSet]
ADD CONSTRAINT [FK_CompteBancaireCoordonneesBancaires]
    FOREIGN KEY ([CompteBancaire_Id])
    REFERENCES [dbo].[CompteBancaireSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompteBancaireCoordonneesBancaires'
CREATE INDEX [IX_FK_CompteBancaireCoordonneesBancaires]
ON [dbo].[CoordonneesBancairesSet]
    ([CompteBancaire_Id]);
GO

-- Creating foreign key on [Contrats_Id] in table 'ContratGroupeDePersonnes'
ALTER TABLE [dbo].[ContratGroupeDePersonnes]
ADD CONSTRAINT [FK_ContratGroupeDePersonnes_Contrat]
    FOREIGN KEY ([Contrats_Id])
    REFERENCES [dbo].[ContratSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GroupesContractants_Id] in table 'ContratGroupeDePersonnes'
ALTER TABLE [dbo].[ContratGroupeDePersonnes]
ADD CONSTRAINT [FK_ContratGroupeDePersonnes_GroupeDePersonnes]
    FOREIGN KEY ([GroupesContractants_Id])
    REFERENCES [dbo].[GroupeDePersonnesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratGroupeDePersonnes_GroupeDePersonnes'
CREATE INDEX [IX_FK_ContratGroupeDePersonnes_GroupeDePersonnes]
ON [dbo].[ContratGroupeDePersonnes]
    ([GroupesContractants_Id]);
GO

-- Creating foreign key on [GroupeDePersonnes_Id] in table 'DroitsGroupeUtilisateursSet'
ALTER TABLE [dbo].[DroitsGroupeUtilisateursSet]
ADD CONSTRAINT [FK_GroupeDePersonnesDroitsGroupeUtilisateurs]
    FOREIGN KEY ([GroupeDePersonnes_Id])
    REFERENCES [dbo].[GroupeDePersonnesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupeDePersonnesDroitsGroupeUtilisateurs'
CREATE INDEX [IX_FK_GroupeDePersonnesDroitsGroupeUtilisateurs]
ON [dbo].[DroitsGroupeUtilisateursSet]
    ([GroupeDePersonnes_Id]);
GO

-- Creating foreign key on [Groupes_Personne_Id] in table 'GroupeDePersonnesPersonne'
ALTER TABLE [dbo].[GroupeDePersonnesPersonne]
ADD CONSTRAINT [FK_Groupes_GroupeDePersonnes]
    FOREIGN KEY ([Groupes_Personne_Id])
    REFERENCES [dbo].[GroupeDePersonnesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Personnes_Id] in table 'GroupeDePersonnesPersonne'
ALTER TABLE [dbo].[GroupeDePersonnesPersonne]
ADD CONSTRAINT [FK_Groupes_Personne]
    FOREIGN KEY ([Personnes_Id])
    REFERENCES [dbo].[PersonneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Groupes_Personne'
CREATE INDEX [IX_FK_Groupes_Personne]
ON [dbo].[GroupeDePersonnesPersonne]
    ([Personnes_Id]);
GO

-- Creating foreign key on [EntrepriseDAppartenance_Id] in table 'GroupeDePersonnesSet'
ALTER TABLE [dbo].[GroupeDePersonnesSet]
ADD CONSTRAINT [FK_PersonneMoraleGroupeDePersonnes]
    FOREIGN KEY ([EntrepriseDAppartenance_Id])
    REFERENCES [dbo].[PersonneSet_Entreprise]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonneMoraleGroupeDePersonnes'
CREATE INDEX [IX_FK_PersonneMoraleGroupeDePersonnes]
ON [dbo].[GroupeDePersonnesSet]
    ([EntrepriseDAppartenance_Id]);
GO

-- Creating foreign key on [Contrat_Id] in table 'DocumentationSet'
ALTER TABLE [dbo].[DocumentationSet]
ADD CONSTRAINT [FK_ContratDocument]
    FOREIGN KEY ([Contrat_Id])
    REFERENCES [dbo].[ContratSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratDocument'
CREATE INDEX [IX_FK_ContratDocument]
ON [dbo].[DocumentationSet]
    ([Contrat_Id]);
GO

-- Creating foreign key on [Documentation_Id] in table 'VersionDeDocumentSet'
ALTER TABLE [dbo].[VersionDeDocumentSet]
ADD CONSTRAINT [FK_DocumentationVersionDeDocument]
    FOREIGN KEY ([Documentation_Id])
    REFERENCES [dbo].[DocumentationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentationVersionDeDocument'
CREATE INDEX [IX_FK_DocumentationVersionDeDocument]
ON [dbo].[VersionDeDocumentSet]
    ([Documentation_Id]);
GO

-- Creating foreign key on [OrigineContrat_Id] in table 'ActionSet'
ALTER TABLE [dbo].[ActionSet]
ADD CONSTRAINT [FK_ContratAction]
    FOREIGN KEY ([OrigineContrat_Id])
    REFERENCES [dbo].[ContratSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratAction'
CREATE INDEX [IX_FK_ContratAction]
ON [dbo].[ActionSet]
    ([OrigineContrat_Id]);
GO

-- Creating foreign key on [ActionAction_Action1_Id] in table 'ActionSet'
ALTER TABLE [dbo].[ActionSet]
ADD CONSTRAINT [FK_ActionAction]
    FOREIGN KEY ([ActionAction_Action1_Id])
    REFERENCES [dbo].[ActionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionAction'
CREATE INDEX [IX_FK_ActionAction]
ON [dbo].[ActionSet]
    ([ActionAction_Action1_Id]);
GO

-- Creating foreign key on [AnomalieDeDocumentation_Id] in table 'ActionSet_Anomalie'
ALTER TABLE [dbo].[ActionSet_Anomalie]
ADD CONSTRAINT [FK_DocumentationAnomalie]
    FOREIGN KEY ([AnomalieDeDocumentation_Id])
    REFERENCES [dbo].[DocumentationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentationAnomalie'
CREATE INDEX [IX_FK_DocumentationAnomalie]
ON [dbo].[ActionSet_Anomalie]
    ([AnomalieDeDocumentation_Id]);
GO

-- Creating foreign key on [AnomalieDeVersionDeDocument_Id] in table 'ActionSet_Anomalie'
ALTER TABLE [dbo].[ActionSet_Anomalie]
ADD CONSTRAINT [FK_VersionDeDocumentAnomalie]
    FOREIGN KEY ([AnomalieDeVersionDeDocument_Id])
    REFERENCES [dbo].[VersionDeDocumentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VersionDeDocumentAnomalie'
CREATE INDEX [IX_FK_VersionDeDocumentAnomalie]
ON [dbo].[ActionSet_Anomalie]
    ([AnomalieDeVersionDeDocument_Id]);
GO

-- Creating foreign key on [AnomalieDeContrat_Id] in table 'ActionSet_Anomalie'
ALTER TABLE [dbo].[ActionSet_Anomalie]
ADD CONSTRAINT [FK_ContratAnomalie]
    FOREIGN KEY ([AnomalieDeContrat_Id])
    REFERENCES [dbo].[ContratSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratAnomalie'
CREATE INDEX [IX_FK_ContratAnomalie]
ON [dbo].[ActionSet_Anomalie]
    ([AnomalieDeContrat_Id]);
GO

-- Creating foreign key on [Immeuble_Id] in table 'LotSet'
ALTER TABLE [dbo].[LotSet]
ADD CONSTRAINT [FK_ImmeubleLot]
    FOREIGN KEY ([Immeuble_Id])
    REFERENCES [dbo].[ImmeubleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImmeubleLot'
CREATE INDEX [IX_FK_ImmeubleLot]
ON [dbo].[LotSet]
    ([Immeuble_Id]);
GO

-- Creating foreign key on [Proprietaire_Id] in table 'LotSet'
ALTER TABLE [dbo].[LotSet]
ADD CONSTRAINT [FK_LotGroupeDeRepartition]
    FOREIGN KEY ([Proprietaire_Id])
    REFERENCES [dbo].[GroupeDePersonnesSet_GroupeDeRepartition]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LotGroupeDeRepartition'
CREATE INDEX [IX_FK_LotGroupeDeRepartition]
ON [dbo].[LotSet]
    ([Proprietaire_Id]);
GO

-- Creating foreign key on [Lot1_Id] in table 'GroupeDePersonnesSet'
ALTER TABLE [dbo].[GroupeDePersonnesSet]
ADD CONSTRAINT [FK_LotGroupeDePersonnes]
    FOREIGN KEY ([Lot1_Id])
    REFERENCES [dbo].[LotSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LotGroupeDePersonnes'
CREATE INDEX [IX_FK_LotGroupeDePersonnes]
ON [dbo].[GroupeDePersonnesSet]
    ([Lot1_Id]);
GO

-- Creating foreign key on [Personne_Id] in table 'PartenaireSet'
ALTER TABLE [dbo].[PartenaireSet]
ADD CONSTRAINT [FK_TiersPersonne]
    FOREIGN KEY ([Personne_Id])
    REFERENCES [dbo].[PersonneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TiersPersonne'
CREATE INDEX [IX_FK_TiersPersonne]
ON [dbo].[PartenaireSet]
    ([Personne_Id]);
GO

-- Creating foreign key on [PartenaireDe_Id] in table 'PartenaireSet'
ALTER TABLE [dbo].[PartenaireSet]
ADD CONSTRAINT [FK_PersonnePartenaire]
    FOREIGN KEY ([PartenaireDe_Id])
    REFERENCES [dbo].[PersonneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonnePartenaire'
CREATE INDEX [IX_FK_PersonnePartenaire]
ON [dbo].[PartenaireSet]
    ([PartenaireDe_Id]);
GO

-- Creating foreign key on [Personne_Id] in table 'CoordonneesDeContactSet'
ALTER TABLE [dbo].[CoordonneesDeContactSet]
ADD CONSTRAINT [FK_PersonneCoordonneesDeContact]
    FOREIGN KEY ([Personne_Id])
    REFERENCES [dbo].[PersonneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonneCoordonneesDeContact'
CREATE INDEX [IX_FK_PersonneCoordonneesDeContact]
ON [dbo].[CoordonneesDeContactSet]
    ([Personne_Id]);
GO

-- Creating foreign key on [Personne_Id] in table 'CoordonneesBancairesSet'
ALTER TABLE [dbo].[CoordonneesBancairesSet]
ADD CONSTRAINT [FK_PersonneCoordonneesBancaires]
    FOREIGN KEY ([Personne_Id])
    REFERENCES [dbo].[PersonneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonneCoordonneesBancaires'
CREATE INDEX [IX_FK_PersonneCoordonneesBancaires]
ON [dbo].[CoordonneesBancairesSet]
    ([Personne_Id]);
GO

-- Creating foreign key on [CompteBancaire_Id] in table 'DocumentationSet'
ALTER TABLE [dbo].[DocumentationSet]
ADD CONSTRAINT [FK_CompteBancaireDocumentation]
    FOREIGN KEY ([CompteBancaire_Id])
    REFERENCES [dbo].[CompteBancaireSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompteBancaireDocumentation'
CREATE INDEX [IX_FK_CompteBancaireDocumentation]
ON [dbo].[DocumentationSet]
    ([CompteBancaire_Id]);
GO

-- Creating foreign key on [AnomalieDeCompteBancaire_Id] in table 'ActionSet_Anomalie'
ALTER TABLE [dbo].[ActionSet_Anomalie]
ADD CONSTRAINT [FK_CompteBancaireAnomalie]
    FOREIGN KEY ([AnomalieDeCompteBancaire_Id])
    REFERENCES [dbo].[CompteBancaireSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompteBancaireAnomalie'
CREATE INDEX [IX_FK_CompteBancaireAnomalie]
ON [dbo].[ActionSet_Anomalie]
    ([AnomalieDeCompteBancaire_Id]);
GO

-- Creating foreign key on [Action_Id] in table 'CompteBancaireSet'
ALTER TABLE [dbo].[CompteBancaireSet]
ADD CONSTRAINT [FK_ActionCompteBancaire]
    FOREIGN KEY ([Action_Id])
    REFERENCES [dbo].[ActionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionCompteBancaire'
CREATE INDEX [IX_FK_ActionCompteBancaire]
ON [dbo].[CompteBancaireSet]
    ([Action_Id]);
GO

-- Creating foreign key on [CommentaireDeContrat_Id] in table 'CommentaireSet'
ALTER TABLE [dbo].[CommentaireSet]
ADD CONSTRAINT [FK_ContratCommentaire]
    FOREIGN KEY ([CommentaireDeContrat_Id])
    REFERENCES [dbo].[ContratSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratCommentaire'
CREATE INDEX [IX_FK_ContratCommentaire]
ON [dbo].[CommentaireSet]
    ([CommentaireDeContrat_Id]);
GO

-- Creating foreign key on [CommentaireDAction_Id] in table 'CommentaireSet'
ALTER TABLE [dbo].[CommentaireSet]
ADD CONSTRAINT [FK_ActionCommentaire]
    FOREIGN KEY ([CommentaireDAction_Id])
    REFERENCES [dbo].[ActionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionCommentaire'
CREATE INDEX [IX_FK_ActionCommentaire]
ON [dbo].[CommentaireSet]
    ([CommentaireDAction_Id]);
GO

-- Creating foreign key on [CommentaireDePersonne_Id] in table 'CommentaireSet'
ALTER TABLE [dbo].[CommentaireSet]
ADD CONSTRAINT [FK_PersonneCommentaire]
    FOREIGN KEY ([CommentaireDePersonne_Id])
    REFERENCES [dbo].[PersonneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonneCommentaire'
CREATE INDEX [IX_FK_PersonneCommentaire]
ON [dbo].[CommentaireSet]
    ([CommentaireDePersonne_Id]);
GO

-- Creating foreign key on [CommentaireDeLot_Id] in table 'CommentaireSet'
ALTER TABLE [dbo].[CommentaireSet]
ADD CONSTRAINT [FK_LotCommentaire]
    FOREIGN KEY ([CommentaireDeLot_Id])
    REFERENCES [dbo].[LotSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LotCommentaire'
CREATE INDEX [IX_FK_LotCommentaire]
ON [dbo].[CommentaireSet]
    ([CommentaireDeLot_Id]);
GO

-- Creating foreign key on [CommentaireDeImmeuble_Id] in table 'CommentaireSet'
ALTER TABLE [dbo].[CommentaireSet]
ADD CONSTRAINT [FK_ImmeubleCommentaire]
    FOREIGN KEY ([CommentaireDeImmeuble_Id])
    REFERENCES [dbo].[ImmeubleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImmeubleCommentaire'
CREATE INDEX [IX_FK_ImmeubleCommentaire]
ON [dbo].[CommentaireSet]
    ([CommentaireDeImmeuble_Id]);
GO

-- Creating foreign key on [Auteur_Id] in table 'CommentaireSet'
ALTER TABLE [dbo].[CommentaireSet]
ADD CONSTRAINT [FK_CommentaireIndividu]
    FOREIGN KEY ([Auteur_Id])
    REFERENCES [dbo].[PersonneSet_Individu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentaireIndividu'
CREATE INDEX [IX_FK_CommentaireIndividu]
ON [dbo].[CommentaireSet]
    ([Auteur_Id]);
GO

-- Creating foreign key on [Individu_Id] in table 'AccesUtilisateurSet'
ALTER TABLE [dbo].[AccesUtilisateurSet]
ADD CONSTRAINT [FK_IndividuAccesUtilisateur]
    FOREIGN KEY ([Individu_Id])
    REFERENCES [dbo].[PersonneSet_Individu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndividuAccesUtilisateur'
CREATE INDEX [IX_FK_IndividuAccesUtilisateur]
ON [dbo].[AccesUtilisateurSet]
    ([Individu_Id]);
GO

-- Creating foreign key on [Id] in table 'PersonneSet_Entreprise'
ALTER TABLE [dbo].[PersonneSet_Entreprise]
ADD CONSTRAINT [FK_Entreprise_inherits_Personne]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonneSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ActionSet_Anomalie'
ALTER TABLE [dbo].[ActionSet_Anomalie]
ADD CONSTRAINT [FK_Anomalie_inherits_Action]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ActionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'GroupeDePersonnesSet_GroupeDeRepartition'
ALTER TABLE [dbo].[GroupeDePersonnesSet_GroupeDeRepartition]
ADD CONSTRAINT [FK_GroupeDeRepartition_inherits_GroupeDePersonnes]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[GroupeDePersonnesSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonneSet_Individu'
ALTER TABLE [dbo].[PersonneSet_Individu]
ADD CONSTRAINT [FK_Individu_inherits_Personne]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonneSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------