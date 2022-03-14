<?xml version="1.0" encoding="UTF-8"?>
<structure version="16" xsltversion="1" html-doctype="HTML4 Transitional" compatibility-view="IE9" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/MVR/MPS/MotorVehicleRegistrationResponse"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="C:\Projects\eGov-MS\AISKAO_XSLTransformations\RegiX\МВР\Регистър МПС\MotorVehicleRegistrationResponse.xsd" workingxmlfile="MotorVehicleRegistrationResponse.xml"/>
		</schemasources>
	</schemasources>
	<modules/>
	<flags>
		<scripts/>
		<mainparts/>
		<globalparts/>
		<designfragments/>
		<pagelayouts/>
		<xpath-functions/>
	</flags>
	<scripts>
		<script language="javascript"/>
	</scripts>
	<script-project>
		<Project version="2" app="AuthenticView"/>
	</script-project>
	<importedxslt/>
	<globalstyles/>
	<mainparts>
		<children>
			<globaltemplate subtype="main" match="/">
				<document-properties/>
				<children>
					<documentsection>
						<properties columncount="1" columngap="0.50in" headerfooterheight="fixed" pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="auto" pagestart="next" paperheight="11in" papermarginbottom="0.79in" papermarginfooter="0.30in" papermarginheader="0.30in" papermarginleft="0.60in" papermarginright="0.60in" papermargintop="0.79in" paperwidth="8.50in"/>
						<watermark>
							<image transparency="50" fill-page="1" center-if-not-fill="1"/>
							<text transparency="50"/>
						</watermark>
					</documentsection>
					<template subtype="source" match="XML">
						<children>
							<template subtype="element" match="n1:MotorVehicleRegistrationResponse">
								<children>
									<paragraph paragraphtag="h3">
										<styles text-align="center"/>
										<children>
											<text fixtext="Справка за МПС по регистрационен номер"/>
										</children>
									</paragraph>
									<template subtype="element" match="n1:Vehicles">
										<children>
											<list ordered="1">
												<children>
													<listrow>
														<children>
															<template subtype="element" match="n1:Vehicle">
																<children>
																	<paragraph paragraphtag="h4">
																		<children>
																			<text fixtext="Информация за МПС"/>
																		</children>
																	</paragraph>
																	<template subtype="element" match="n1:VehicleRegistrationNumber">
																		<children>
																			<text fixtext="Регистрационен номер на МПС: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:FirstRegistrationDate">
																		<children>
																			<newline/>
																			<text fixtext="Дата на първа регистрация:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<content subtype="regular">
																				<format basic-type="xsd" string="DD.MM.YYYY" datatype="dateTime"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:MotorVehicleRegistrationCertificateNumber">
																		<children>
																			<newline/>
																			<text fixtext="Номер на документ:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<newline/>
																	<condition>
																		<children>
																			<conditionbranch xpath="string-length( n1:OwnerPersonData/n1:EGN )&gt;0 or string-length( n1:OwnerPersonData/n1:FirsName )&gt;0 or string-length( n1:OwnerPersonData/n1:Surname )&gt;0 or string-length( n1:OwnerPersonData/n1:FamilyName )&gt;0 or string-length( n1:OwnerPersonData/n1:FirstNameLatin )&gt;0 or string-length( n1:OwnerPersonData/n1:SurnameLatin )&gt;0 or string-length( n1:OwnerPersonData/n1:LastNameLatin )&gt;0 or string-length( n1:OwnerEntityData/n1:Identifier )&gt;0 or string-length( n1:OwnerEntityData/n1:Name )&gt;0 or string-length( n1:OwnerEntityData/n1:NameLatin )&gt;0">
																				<children>
																					<paragraph paragraphtag="h4">
																						<children>
																							<text fixtext="Собственик на МПС:"/>
																						</children>
																					</paragraph>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="n1:OwnerPersonData">
																		<children>
																			<template subtype="element" match="n1:EGN">
																				<children>
																					<text fixtext="ЕГН: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length( n1:FirsName )&gt;0 or string-length( n1:Surname )&gt;0 or string-length( n1:FamilyName )&gt;0 or string-length( n1:FirstNameLatin )&gt;0 or string-length( n1:SurnameLatin )&gt;0 or string-length( n1:LastNameLatin )&gt;0">
																						<children>
																							<newline/>
																							<text fixtext="Име: ">
																								<styles font-weight="bold"/>
																							</text>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:FirstName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="n1:Surname">
																				<children>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<text fixtext=" "/>
																			<template subtype="element" match="n1:FamilyName">
																				<children>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length( n1:FirstNameLatin )&gt;0 or string-length( n1:SurnameLatin )&gt;0 or string-length( n1:LastNameLatin )">
																						<children>
																							<text fixtext=" ("/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:FirstNameLatin">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="n1:SurnameLatin">
																				<children>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="n1:LastNameLatin">
																				<children>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length( n1:FirstNameLatin )&gt;0 or string-length( n1:SurnameLatin )&gt;0 or string-length( n1:LastNameLatin )&gt;0">
																						<children>
																							<text fixtext=")"/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<newline/>
																			<condition>
																				<children>
																					<conditionbranch xpath="count(n1:BirthDate/node()) &gt; 0">
																						<children>
																							<text fixtext="Дата на раждане:">
																								<styles font-weight="bold"/>
																							</text>
																							<text fixtext=" "/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:BirthDate">
																				<children>
																					<content subtype="regular">
																						<format basic-type="xsd" string="DD.MM.YYYY" datatype="dateTime"/>
																					</content>
																				</children>
																				<variables/>
																			</template>
																			<newline/>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:GenderName) &gt; 0 or string-length(n1:GenderNameLatin) &gt; 0">
																						<children>
																							<text fixtext="Пол:">
																								<styles font-weight="bold"/>
																							</text>
																							<text fixtext=" "/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:GenderName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:GenderName) &gt; 0 and string-length(n1:GenderNameLatin) &gt; 0">
																						<children>
																							<text fixtext=" ("/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:GenderNameLatin">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:GenderName) &gt; 0 or string-length(n1:GenderNameLatin) &gt; 0">
																						<children>
																							<text fixtext=")"/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<newline/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:OwnerEntityData">
																		<children>
																			<template subtype="element" match="n1:Identifier">
																				<children>
																					<text fixtext="ЕИК: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length( n1:Name )&gt; 0 or string-length( n1:NameLatin )&gt;0">
																						<children>
																							<newline/>
																							<text fixtext="Име: ">
																								<styles font-weight="bold"/>
																							</text>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:Name">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:Name) &gt; 0 and string-length(n1:NameLatin) &gt; 0">
																						<children>
																							<text fixtext=" ("/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:NameLatin">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:Name) &gt; 0 and string-length(n1:NameLatin) &gt; 0">
																						<children>
																							<text fixtext=")"/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:OwnerForeignerPersonData">
																		<children>
																			<newline/>
																			<template subtype="element" match="n1:EGN">
																				<children>
																					<text fixtext="ЕГН:">
																						<styles font-weight="bold"/>
																					</text>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="n1:LNCh">
																				<children>
																					<text fixtext="ЛНЧ:">
																						<styles font-weight="bold"/>
																					</text>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																					<newline/>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="n1:Names">
																				<children>
																					<text fixtext="Имена:">
																						<styles font-weight="bold"/>
																					</text>
																					<text fixtext=" "/>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:Names) &gt; 0 and string-length(n1:NamesLatin) &gt; 0">
																						<children>
																							<text fixtext=" ("/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:NamesLatin">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:Names) &gt; 0 and string-length(n1:NamesLatin) &gt; 0">
																						<children>
																							<text fixtext=")"/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<newline/>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:GenderName) &gt; 0 or string-length(n1:GenderNameLatin) &gt; 0">
																						<children>
																							<text fixtext="Пол: ">
																								<styles font-weight="bold"/>
																							</text>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:GenderName">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:GenderName) &gt; 0 and string-length(n1:GenderNameLatin) &gt; 0">
																						<children>
																							<text fixtext=" ("/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																			<template subtype="element" match="n1:GenderNameLatin">
																				<children>
																					<content subtype="regular"/>
																				</children>
																				<variables/>
																			</template>
																			<condition>
																				<children>
																					<conditionbranch xpath="string-length(n1:GenderName) &gt; 0 or string-length(n1:GenderNameLatin) &gt; 0">
																						<children>
																							<text fixtext=")"/>
																						</children>
																					</conditionbranch>
																				</children>
																			</condition>
																		</children>
																		<variables/>
																	</template>
																	<newline/>
																	<newline/>
																	<template subtype="element" match="n1:MotorVehicleType">
																		<children>
																			<newline/>
																			<text fixtext="Вид МПС на кирилица:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:MotorVehicleTypeLatin">
																		<children>
																			<newline/>
																			<text fixtext="Вид МПС на латиница: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:MotorVehicleModel">
																		<children>
																			<newline/>
																			<text fixtext="Марка (модел) на кирилица: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:MotorVehicleModelLatin">
																		<children>
																			<newline/>
																			<text fixtext="Марка (модел) на латиница:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:MotorVehicleModelType">
																		<children>
																			<newline/>
																			<text fixtext="Тип, вариант и версия на МПС на кирилица:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:TradeDescription">
																		<children>
																			<newline/>
																			<text fixtext="Търговско описание на кирилица: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:TradeDescriptionLatin">
																		<children>
																			<newline/>
																			<text fixtext="Търговско описание на латиница: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:VINNumber">
																		<children>
																			<newline/>
																			<text fixtext="Идентификационен номер на МПС (VIN): ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:IssueDate">
																		<children>
																			<newline/>
																			<text fixtext="Дата на издаване на свидетелството: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular">
																				<format basic-type="xsd" string="DD.MM.YYYY" datatype="dateTime"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:Category">
																		<children>
																			<newline/>
																			<text fixtext="Категория на превозното средство:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:Color">
																		<children>
																			<newline/>
																			<text fixtext="Цвят на МПС на кирилица: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:ColorLatin">
																		<children>
																			<newline/>
																			<text fixtext="Цвят на МПС на латиница: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:EngineNumber">
																		<children>
																			<newline/>
																			<text fixtext="Номер на двигател:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:ColorSecondary">
																		<children>
																			<newline/>
																			<text fixtext="Допълнителен цвят на МПС на кирилица: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="n1:ColorSecondaryLatin">
																		<children>
																			<newline/>
																			<text fixtext="Допълнителен цвят на МПС на латиница: ">
																				<styles font-weight="bold"/>
																			</text>
																			<content subtype="regular"/>
																		</children>
																		<variables/>
																	</template>
																	<newline/>
																</children>
																<variables/>
															</template>
														</children>
													</listrow>
												</children>
											</list>
										</children>
										<variables/>
									</template>
								</children>
								<variables/>
							</template>
						</children>
						<variables/>
					</template>
				</children>
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<designfragments/>
	<xmltables/>
	<authentic-custom-toolbar-buttons/>
</structure>
