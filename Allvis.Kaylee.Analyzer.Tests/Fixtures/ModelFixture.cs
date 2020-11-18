namespace Allvis.Kaylee.Analyzer.Tests.Fixtures
{
    public static class ModelFixture
    {
        public static string Create()
            => @"
schema auth {
    entity User {
        fields {
            UserId GUID {
                default = NEWID();
            }
            CreatedAt DATE {
                default = SYSDATETIMEOFFSET();
            }
            FirstName? TEXT(100);
            LastName? TEXT(100);
            ContactEmail? TEXT(254);
            ContactPhone? TEXT(50);
            Verified BIT {
                default = 0;
            }
            SuperUser BIT {
                default = 0;
            }
            NormalizedContactEmail TEXT(254) {
                computed = true;
            }
        }

        keys {
            primary = UserId;
        }

        mutations {
            Name(FirstName, LastName);
            ContactInformation(ContactEmail, ContactPhone);
            Verified(Verified);
        }
    }
}

schema tenant {
    entity Tenant {
        fields {
            TenantId GUID {
                default = NEWID();
            }
            Name TEXT(100);
            Identifier TEXT(100);
            ETag ROWVERSION;
        }

        keys {
            primary = TenantId;
        }

        entity Procedure {
            fields {
                ProcedureId GUID {
                    default = NEWID();
                }
            }
            
            keys {
                primary = ProcedureId;
            }

            entity Revision {
                fields {
                    RevisionNo  TEXT ( 10 );
                }

                keys {
                    primary = RevisionNo;
                }

                entity Execution {
                    fields {
                        ExecutionId GUID {
                            default = NEWID();
                        }
                        StartedAt   DATE {
                            default = SYSDATETIMEOFFSET();
                        }
                        ETag        ROWVERSION;
                    }

                    keys {
                        primary = ExecutionId;
                    }

                    entity Comment {
                        fields {
                            CommentId         INT AUTO INCREMENT;
                            Step?             INT;
                            CommentedByUserId GUID;
                            ReceivedAt        DATE {
                                default = SYSDATETIMEOFFSET();
                            }
                            Comment           TEXT(500);
                        }

                        keys {
                            primary = CommentId;

                            reference(CommentedByUserId) => auth::User(UserId);
                        }

                        entity Delivery {
                            fields {
                                UserId     GUID;
                                ReceivedAt DATE {
                                    default = SYSDATETIMEOFFSET();
                                }
                                SeenAt?    DATE;
                            }

                            keys {
                                primary = UserId;

                                reference(UserId) => auth::User(UserId);
                            }
                        }

                        entity Reaction {
                            fields {
                                UserId    GUID;
                                ReactedAt DATE {
                                    default = SYSDATETIMEOFFSET();
                                }
                                Emoji     CHAR;
                            }

                            keys {
                                primary = UserId;

                                reference(UserId) => auth::User(UserId);
                            }
                        }
                    }
                }
            }
        }
    }
}
";
    }
}
