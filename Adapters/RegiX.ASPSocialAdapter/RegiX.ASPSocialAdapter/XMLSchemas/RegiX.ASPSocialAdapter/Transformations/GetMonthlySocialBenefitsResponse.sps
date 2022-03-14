<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/ASP/Common"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/ASP/MonthlyBenefits/GetMonthlySocialBenefitsResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.ASPSocialAdapter\XMLSchemas\GetMonthlySocialBenefitsResponse.xsd" workingxmlfile="GetMonthlySocialBenefitsResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:GetMonthlySocialBenefitsResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<newline/>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Министерство на труда и социалната политика"/>										</children>									</paragraph>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Агенция за социално подпомагане"/>										</children>									</paragraph>									<paragraph paragraphtag="h2">										<properties align="center"/>										<children>											<text fixtext="Справка по ЕГН/ЛНЧ за отпуснати месечни помощи по чл. 9 от ППЗСП към дата "/>											<template match="n1:CurrentTime" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<content>														<format string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>													</content>													<text fixtext=" "/>												</children>											</template>											<text fixtext=" "/>										</children>									</paragraph>									<text fixtext=" ">										<styles font-size="small"/>									</text>									<template match="n1:PersonData" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<condition>												<children>													<conditionbranch xpath="count( .) != 0 and count( common:Gender/common:GenderName ) !=  0">														<children>															<paragraph paragraphtag="h3">																<children>																	<text fixtext="Данни за лицето:"/>																</children>															</paragraph>															<table>																<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<children>																					<tablecell>																						<properties valign="top" width="150"/>																						<children>																							<text fixtext="Имена:"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:FirstName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																							<template match="common:MiddleName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<text fixtext=" ">																										<styles font-size="small"/>																									</text>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																							<template match="common:LastName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<text fixtext=" ">																										<styles font-size="small"/>																									</text>																									<content>																										<format datatype="string"/>																									</content>																									<newline/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>															<template match="common:BirthDatе" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<table>																		<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>																		<children>																			<tablebody>																				<children>																					<tablerow>																						<children>																							<tablecell>																								<properties valign="top" width="150"/>																								<children>																									<text fixtext="Дата на раждане:"/>																								</children>																							</tablecell>																							<tablecell>																								<children>																									<content>																										<format string="DD.MM.YYYY" datatype="date"/>																									</content>																									<text fixtext=" г."/>																								</children>																							</tablecell>																						</children>																					</tablerow>																				</children>																			</tablebody>																		</children>																	</table>																</children>															</template>															<template match="common:Gender" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="common:GenderName" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<table>																				<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>																				<children>																					<tablebody>																						<children>																							<tablerow>																								<children>																									<tablecell>																										<properties valign="top" width="150"/>																										<children>																											<text fixtext="Пол:"/>																										</children>																									</tablecell>																									<tablecell>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</tablecell>																								</children>																							</tablerow>																						</children>																					</tablebody>																				</children>																			</table>																		</children>																	</template>																</children>															</template>															<table>																<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<children>																					<tablecell>																						<properties valign="top" width="150"/>																						<children>																							<template match="common:IdentifierType" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<condition>																										<children>																											<conditionbranch xpath=". = &quot;EGN&quot;">																												<children>																													<text fixtext="ЕГН"/>																												</children>																											</conditionbranch>																											<conditionbranch xpath=". = &quot;LNCh&quot;">																												<children>																													<text fixtext="ЛНЧ"/>																												</children>																											</conditionbranch>																										</children>																									</condition>																									<text fixtext=": "/>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:Identifier" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																									<newline/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</conditionbranch>													<conditionbranch xpath="count( .) = 0 or count( common:Gender/common:GenderName ) =  0">														<children>															<text fixtext="Няма данни за лицето!">																<styles font-size="small" font-style="italic"/>															</text>														</children>													</conditionbranch>												</children>											</condition>										</children>									</template>									<newline/>									<condition>										<children>											<conditionbranch xpath="count( n1:DecisionData ) != 0">												<children>													<table>														<properties border="1" cellpadding="0" cellspacing="0" width="100%"/>														<styles border-collapse="collapse" font-size="small"/>														<children>															<tableheader>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties colspan="2"/>																				<children>																					<text fixtext="Заповед">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties colspan="2"/>																				<children>																					<text fixtext="Организационна единица, издала заповедта">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties rowspan="2"/>																				<children>																					<text fixtext="Дата, на която спира изплащането">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties rowspan="2"/>																				<children>																					<text fixtext="Изтекла ли е молбата">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties colspan="2"/>																				<children>																					<text fixtext="Нормативно основание">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																		</children>																	</tablerow>																	<tablerow>																		<children>																			<tablecell headercell="1">																				<children>																					<text fixtext="№">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<children>																					<text fixtext="Дата">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<children>																					<text fixtext="Код">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<children>																					<text fixtext="Наименование">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<children>																					<text fixtext="Kод">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<children>																					<text fixtext="Наименование">																						<styles font-size="small"/>																					</text>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tableheader>															<tablebody>																<children>																	<template match="n1:DecisionData" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell>																						<styles padding="2px"/>																						<children>																							<template match="common:Details" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<template match="common:DecisionNumber" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<styles padding="2px"/>																						<children>																							<template match="common:Details" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<template match="common:Date" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format string="DD.MM.YYYY" datatype="date"/>																											</content>																											<text fixtext=" г."/>																										</children>																									</template>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<styles padding="2px"/>																						<children>																							<template match="common:Details" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<template match="common:OrganizationUnitCode" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<styles padding="2px"/>																						<children>																							<template match="common:Details" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<template match="common:OrganizationUnitName" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<styles padding="2px"/>																						<children>																							<template match="common:RequestEndDate" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format string="DD.MM.YYYY" datatype="date"/>																									</content>																									<text fixtext=" г."/>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<styles padding="2px"/>																						<children>																							<template match="common:IsArchivedRequest" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<condition>																										<children>																											<conditionbranch xpath=". = &apos;true&apos;">																												<children>																													<text fixtext="Да">																														<styles font-size="small"/>																													</text>																												</children>																											</conditionbranch>																											<conditionbranch xpath=". = &apos;false&apos;">																												<children>																													<text fixtext="Не">																														<styles font-size="small"/>																													</text>																												</children>																											</conditionbranch>																										</children>																									</condition>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<styles padding="2px"/>																						<children>																							<template match="common:LegalGroundCode" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<styles font-size="small"/>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<styles padding="2px"/>																						<children>																							<template match="common:LegalGroundName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<styles font-size="small"/>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</template>																</children>															</tablebody>														</children>													</table>												</children>											</conditionbranch>											<conditionbranch xpath="count( n1:DecisionData ) = 0">												<children>													<text fixtext="Няма данни за заповеди!">														<styles font-size="small" font-style="italic"/>													</text>												</children>											</conditionbranch>										</children>									</condition>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>