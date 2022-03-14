<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/Iaaa/EducationCenters"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/Iaaa/EducationCenters/SubjectOwnedCategoriesResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.IaaaEducationCentersAdapter\XMLSchemas\Report6_subjectOwnedCategoriesResponse.xsd" workingxmlfile="Report6_subjectOwnedCategoriesResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:SubjectOwnedCategoriesResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Изпълнителна агенция „Автомобилна администрация“;"/>										</children>									</paragraph>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Регистър за издадените удостоверения за регистрация за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им"/>										</children>									</paragraph>									<paragraph paragraphtag="h2">										<properties align="center"/>										<children>											<text fixtext="Справка по ЕГН/ЛНЧ за придобити категории за управление на ППС"/>										</children>									</paragraph>									<condition>										<children>											<conditionbranch xpath="string-length(n1:OwnedCategories )&gt;0">												<children>													<template match="n1:OwnedCategories" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<newline/>															<table>																<properties border="1" cellpadding="1" cellspacing="1"/>																<styles border-collapse="collapse"/>																<children>																	<tableheader>																		<children>																			<tablerow>																				<children>																					<tablecell>																						<properties align="center" width="60px"/>																						<children>																							<text fixtext="№">																								<styles font-weight="bold"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<children>																							<text fixtext="Категория">																								<styles font-weight="bold"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center" width="238"/>																						<children>																							<text fixtext="Дата на придобиване на категорията">																								<styles font-weight="bold"/>																							</text>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tableheader>																	<tablebody>																		<children>																			<template match="n1:OwnedCategorie" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<tablerow>																						<children>																							<tablecell>																								<properties align="center" width="60px"/>																								<children>																									<autocalc xpath="position()"/>																								</children>																							</tablecell>																							<tablecell>																								<children>																									<template match="n1:CategoryName" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																							<tablecell>																								<properties align="center"/>																								<children>																									<template match="n1:DateOwned" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format string="DD.MM.YYYY" datatype="date"/>																											</content>																											<text fixtext=" г."/>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																				</children>																				<sort>																					<key match="n1:CategoryName"/>																				</sort>																			</template>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>												</children>											</conditionbranch>											<conditionbranch>												<children>													<text fixtext="Няма намерени данни в регистъра!"/>												</children>											</conditionbranch>										</children>									</condition>								</children>							</template>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>